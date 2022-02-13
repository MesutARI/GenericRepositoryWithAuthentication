using GenericRepoGenericRepositoryWithAuthenticationsitory.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region variables
        private readonly NorthwindContext _context;
        private readonly DbSet<User> _dbSet;

        #endregion

        #region UserRepository
        public UserRepository(NorthwindContext _context)
        {
            this._context = _context;
            _dbSet = this._context.Set<User>();
        }
       
        #endregion

        #region Methods

        #region GetByIdAsync
        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        #endregion

        #region GetUserWithNamePassword
        public User GetUserWithNamePassword(string name, string password)
        {
            return _dbSet.Where(r => r.UserName == name && r.Password == password).FirstOrDefault();
        }
        #endregion

        #region GetUserWithRefreshToken
        public User GetUserWithRefreshToken(string refreshToken)
        {
            //User usr= _dbSet.FirstOrDefault(r => r.RefreshToken.ToString() == refreshToken);
            //return usr;
            return _dbSet.FirstOrDefault(r => r.RefreshToken== refreshToken);
        }
        #endregion

        #region RemoveRefreshToken
        public void RemoveRefreshToken(User user)
        {
            User new_user = GetByIdAsync(user.UserId).Result; //this.FindById(user.UserID);

            new_user.RefreshToken = null;
            new_user.RefreshTokenEndDate = null;
        }
        #endregion

        #region SaveRefreshToken
        public void SaveRefreshToken(int userId, string refreshToken)
        {
            User new_user = GetByIdAsync(userId).Result; //this.FindById(userId);
            new_user.RefreshToken = refreshToken;
            //new_user.RefreshTokenEndDate = DateTime.Now.AddMinutes(60);
            new_user.RefreshTokenEndDate = DateTime.Now.AddMinutes( BaseClass.tokenOptions.RefreshTokenExpiration);
        }
        #endregion

        #endregion
    }
}
