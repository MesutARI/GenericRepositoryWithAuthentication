using GenericRepositoryWithAuthentication.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Core.Repositories
{
    public interface IUserRepository 
    {
        Task<User> GetByIdAsync(int id);

        User GetUserWithNamePassword(string userName, string password);

        User GetUserWithRefreshToken(string refreshToken);

        void SaveRefreshToken(int userId, string refreshToken);

        void RemoveRefreshToken(User user);


    }
}
