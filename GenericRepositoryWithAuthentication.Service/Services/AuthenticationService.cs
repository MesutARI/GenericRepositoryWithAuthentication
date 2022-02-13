using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryWithAuthentication.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region variables
        private readonly ITokenHandler tokenHandler;
        private readonly IUnitOfWork unitOfWorks;
        #endregion

        #region AuthenticationService
        public AuthenticationService(ITokenHandler tokenHandler, IUnitOfWork unitOfWorks)
        {
            this.tokenHandler = tokenHandler;
            this.unitOfWorks = unitOfWorks;
        }
        #endregion

        #region Methods
        public GenericResponse<AccessToken> CreateAccessToken(string userName, string psw)
        {
            try
            {
                //GenericResponse<User> t = userService.GetUserWithNamePassword(userName, psw);
                GenericResponse<User> t = unitOfWorks.UserServices.GetUserWithNamePassword(userName, psw);

                if (t.Success)
                {
                    AccessToken accessToken = tokenHandler.CreateAccesToken(t.Tables);
                    unitOfWorks.UserServices.SaveRefreshToken(t.Tables.UserId, accessToken.RefreshToken);
                    unitOfWorks.Complete();
                    return new GenericResponse<AccessToken>(accessToken);
                }
                else if (t.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return new GenericResponse<AccessToken>(t.Message, System.Net.HttpStatusCode.NotFound);
                else
                    return new GenericResponse<AccessToken>(t.Message, System.Net.HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return new GenericResponse<AccessToken>(ex.Message, System.Net.HttpStatusCode.BadRequest);

            }
        }

        public GenericResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshtoken)
        {
            GenericResponse<User> t = unitOfWorks.UserServices.GetUserWithRefreshToken(refreshtoken);

            if (t.Success)
            {
                if (t.Tables.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = tokenHandler.CreateAccesToken(t.Tables);
                    unitOfWorks.UserServices.SaveRefreshToken(t.Tables.UserId, accessToken.RefreshToken);
                    unitOfWorks.Complete();
                    return new GenericResponse<AccessToken>(accessToken);
                }
                else
                {
                    return new GenericResponse<AccessToken>("!!! This token has expired", System.Net.HttpStatusCode.BadRequest);
                }
            }
            else if (t.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new GenericResponse<AccessToken>(t.Message, System.Net.HttpStatusCode.NotFound);
            else
                return new GenericResponse<AccessToken>("This token has not found", System.Net.HttpStatusCode.BadRequest);

        }

        public GenericResponse<AccessToken> RevokeRefreshToken(string refreshtoken)
        {
            GenericResponse<User> t = unitOfWorks.UserServices.GetUserWithRefreshToken(refreshtoken);
            if (t.Success)
            {
                unitOfWorks.UserServices.RemoveRefreshToken(t.Tables);
                unitOfWorks.Complete();
                return new GenericResponse<AccessToken>(new AccessToken());
            }
            else
            {
                return new GenericResponse<AccessToken>("!!! This token has expired", System.Net.HttpStatusCode.BadRequest);
            }
        }

        #endregion
    }
}
