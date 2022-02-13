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
	public partial class CustomerService :GenericService<Customer>, ICustomerService
    {
		public CustomerService(ICustomerRepository repository) : base(repository)
        {
        }
		public CustomerRepository _repository { get { return _repository as CustomerRepository; } }

	}
}
