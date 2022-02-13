using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Services;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Service.Services
{
    public partial class UserService : IUserService
    {
        #region variables
        private readonly IUserRepository _repository;

        #endregion

        #region UserService
        public UserService(IUserRepository _repository)
        {
            this._repository = _repository;
        }
        #endregion

        #region Methods

        #region GetByIdAsync
        public async Task<GenericResponse<User>> GetByIdAsync(int id)
        {
            try
            {
                User t = await this._repository.GetByIdAsync(id);
                if (t != null)
                    return new GenericResponse<User>(t);
                return new GenericResponse<User>($"!!! Unable to find any User", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {

                return new GenericResponse<User>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region GetUserWithNamePassword
        public GenericResponse<User> GetUserWithNamePassword(string userName, string password)
        {
            try
            {
                User t = this._repository.GetUserWithNamePassword(userName, password);
                if (t != null)
                    return new GenericResponse<User>(t);
                return new GenericResponse<User>($"!!! Unable to find any User", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new GenericResponse<User>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region GetUserWithRefreshToken
        public GenericResponse<User> GetUserWithRefreshToken(string refreshToken)
        {
            try
            {
                User _user = _repository.GetUserWithRefreshToken(refreshToken);
                if (_user != null)
                    return new GenericResponse<User>(_user);
                return new GenericResponse<User>($"!!! Unable to find any User", HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return new GenericResponse<User>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region RemoveRefreshToken
        public void RemoveRefreshToken(User user)
        {
            try
            {
                _repository.RemoveRefreshToken(user);
                //unitOfWorks.Complete();
                //await unitOfWorks.CompleteAsync();
            }
            catch
            {
                // log
                //return new GenericResponse<User>($"Fail:: {ex.Message}", HttpStatusCode.BadRequest);
            }
        }
        #endregion

        #region SaveRefreshToken
        public void SaveRefreshToken(int userId, string refreshToken)
        {
            try
            {
                _repository.SaveRefreshToken(userId, refreshToken);
            }
            catch (Exception)
            {
                // log
            }
        }
        #endregion

        #endregion
    }
}
