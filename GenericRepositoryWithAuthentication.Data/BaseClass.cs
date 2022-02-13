using GenericRepoGenericRepositoryWithAuthenticationsitory.Core.Security.Models;
using Microsoft.Extensions.Configuration;

namespace GenericRepositoryWithAuthentication.Data
{
    public static class BaseClass
    {
        public static IConfiguration Configuration;
        public static TokenOptions tokenOptions;
    }
}
