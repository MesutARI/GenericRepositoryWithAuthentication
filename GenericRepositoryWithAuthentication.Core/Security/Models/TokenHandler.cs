using GenericRepoGenericRepositoryWithAuthenticationsitory.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GenericRepositoryWithAuthentication.Core.Security.Models
{
    public class TokenHandler : ITokenHandler
    {
        #region variables
        private readonly TokenOptions tokenOptions;
        #endregion

        #region TokenHandler
        public TokenHandler(IOptions<TokenOptions> tokenoptions)
        {
            this.tokenOptions = tokenoptions.Value;
            IdentityModelEventSource.ShowPII = true;
        }
        #endregion

        #region Methods
        public AccessToken CreateAccesToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);

            var securityKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey);
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken Jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaim(user),
                signingCredentials: signingCredentials

                );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(Jwt);

            AccessToken accessToken = new AccessToken
            {
                Token = token,
                RefreshToken = CreateRefreshToken(),
                Expiration = accessTokenExpiration
            };

            return accessToken;
        }

        private string CreateRefreshToken()
        {
            var numberbyte = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberbyte);

                return Convert.ToBase64String(numberbyte);
            }
        }

        private IEnumerable<Claim> GetClaim(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                //new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            return claims;
        }

        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
            user.RefreshTokenEndDate = null;
        }

        #endregion
    }
}
