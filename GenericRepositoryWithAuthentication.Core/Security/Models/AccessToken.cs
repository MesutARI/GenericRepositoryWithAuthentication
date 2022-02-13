using System;

namespace GenericRepositoryWithAuthentication.Core.Security.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
