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
	public partial class CustomerDemographicService :GenericService<CustomerDemographic>, ICustomerDemographicService
    {
		public CustomerDemographicService(ICustomerDemographicRepository repository) : base(repository)
        {
        }
		public CustomerDemographicRepository _repository { get { return _repository as CustomerDemographicRepository; } }

	}
}
