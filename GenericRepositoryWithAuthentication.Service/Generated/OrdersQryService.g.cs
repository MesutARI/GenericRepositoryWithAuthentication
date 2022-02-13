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
	public partial class OrdersQryService :GenericService<OrdersQry>, IOrdersQryService
    {
		public OrdersQryService(IOrdersQryRepository repository) : base(repository)
        {
        }
		public OrdersQryRepository _repository { get { return _repository as OrdersQryRepository; } }

	}
}
