using GenericRepositoryWithAuthentication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryWithAuthentication.Core.Security.Models
{
    public interface ITokenHandler
    {
        AccessToken CreateAccesToken(User user);

        void RevokeRefreshToken(User user);
    }
}
