// 
// This is an auto generated file. 
// Do not make manual change
//  

using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;
using GenericRepositoryWithAuthentication.Core.Services;
using GenericRepositoryWithAuthentication.Data.Repositories;

namespace GenericRepositoryWithAuthentication.Service.Services
{
	public partial class SupplierService :GenericService<Supplier>, ISupplierService
    {
		public SupplierService(ISupplierRepository repository) : base(repository)
        {
        }
		public SupplierRepository _repository { get { return _repository as SupplierRepository; } }

	}
}
