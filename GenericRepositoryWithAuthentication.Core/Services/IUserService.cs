using GenericRepositoryWithAuthentication.Core.Models;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Core.Services
{
    public interface IUserService
    {
        Task<GenericResponse<User>> GetByIdAsync(int id);

        GenericResponse<User> GetUserWithNamePassword(string userName, string password);

        GenericResponse<User> GetUserWithRefreshToken(string refreshToken);

        void SaveRefreshToken(int userId, string refreshToken);

        void RemoveRefreshToken(User user);

    }
}
