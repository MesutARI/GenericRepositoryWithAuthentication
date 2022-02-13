using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GenericRepositoryWithAuthentication.Core.Security.Models
{
    public static class SignHandler
    {
        public static SecurityKey GetSecurityKey(string securitykey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securitykey));
            // new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
        }
    }
}
