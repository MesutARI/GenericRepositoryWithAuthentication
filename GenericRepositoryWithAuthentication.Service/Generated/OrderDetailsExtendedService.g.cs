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
	public partial class OrderDetailsExtendedService :GenericService<OrderDetailsExtended>, IOrderDetailsExtendedService
    {
		public OrderDetailsExtendedService(IOrderDetailsExtendedRepository repository) : base(repository)
        {
        }
		public OrderDetailsExtendedRepository _repository { get { return _repository as OrderDetailsExtendedRepository; } }

	}
}
