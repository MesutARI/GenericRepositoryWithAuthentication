using GenericRepositoryWithAuthentication.Core.Services;
using System;
using System.Threading.Tasks;

namespace GenericRepositoryWithAuthentication.Core.UnitOfWorks
{
    public partial interface IUnitOfWork : IDisposable
    {
        public IUserService UserServices{ get; }

        void Complete();
        Task CompleteAsync();
    }
}
