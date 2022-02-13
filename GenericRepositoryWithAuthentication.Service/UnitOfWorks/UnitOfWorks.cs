using GenericRepoGenericRepositoryWithAuthenticationsitory.Core.Security.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Core.UnitOfWorks;
using GenericRepositoryWithAuthentication.Data.Repositories;
using GenericRepositoryWithAuthentication.Service.Services;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Service.UnitOfWorks
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _IUserRepository;
        private IUserRepository UserRepository => _IUserRepository ??= new UserRepository(_context);

        private IUserService _UserService;
        public IUserService UserServices => _UserService ??= new UserService(UserRepository);

        #region Complete
        public void Complete()
        {
            this._context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await this._context.SaveChangesAsync();
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion
    }
}
