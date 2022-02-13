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
	public partial class CustomerCustomerDemoService :GenericService<CustomerCustomerDemo>, ICustomerCustomerDemoService
    {
		public CustomerCustomerDemoService(ICustomerCustomerDemoRepository repository) : base(repository)
        {
        }
		public CustomerCustomerDemoRepository _repository { get { return _repository as CustomerCustomerDemoRepository; } }

	}
}
