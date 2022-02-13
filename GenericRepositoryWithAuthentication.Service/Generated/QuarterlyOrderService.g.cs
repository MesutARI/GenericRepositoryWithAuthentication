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
	public partial class QuarterlyOrderService :GenericService<QuarterlyOrder>, IQuarterlyOrderService
    {
		public QuarterlyOrderService(IQuarterlyOrderRepository repository) : base(repository)
        {
        }
		public QuarterlyOrderRepository _repository { get { return _repository as QuarterlyOrderRepository; } }

	}
}
