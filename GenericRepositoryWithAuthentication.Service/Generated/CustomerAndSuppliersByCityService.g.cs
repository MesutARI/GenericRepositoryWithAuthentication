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
	public partial class CustomerAndSuppliersByCityService :GenericService<CustomerAndSuppliersByCity>, ICustomerAndSuppliersByCityService
    {
		public CustomerAndSuppliersByCityService(ICustomerAndSuppliersByCityRepository repository) : base(repository)
        {
        }
		public CustomerAndSuppliersByCityRepository _repository { get { return _repository as CustomerAndSuppliersByCityRepository; } }

	}
}
