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
	public partial class OrderSubtotalService :GenericService<OrderSubtotal>, IOrderSubtotalService
    {
		public OrderSubtotalService(IOrderSubtotalRepository repository) : base(repository)
        {
        }
		public OrderSubtotalRepository _repository { get { return _repository as OrderSubtotalRepository; } }

	}
}
