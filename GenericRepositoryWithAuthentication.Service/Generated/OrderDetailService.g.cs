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
	public partial class OrderDetailService :GenericService<OrderDetail>, IOrderDetailService
    {
		public OrderDetailService(IOrderDetailRepository repository) : base(repository)
        {
        }
		public OrderDetailRepository _repository { get { return _repository as OrderDetailRepository; } }

	}
}
