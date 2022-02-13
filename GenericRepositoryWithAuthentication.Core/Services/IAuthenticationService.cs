using GenericRepositoryWithAuthentication.Core.Security.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryWithAuthentication.Core.Services
{
    public interface IAuthenticationService
    {
        GenericResponse<AccessToken> CreateAccessToken(string userName, string psw);
        GenericResponse<AccessToken> CreateAccessTokenByRefreshToken(string refreshToken);
        GenericResponse<AccessToken> RevokeRefreshToken(string refreshToken);
    }
}
