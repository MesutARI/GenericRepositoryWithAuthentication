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
	public partial class CurrentProductListService :GenericService<CurrentProductList>, ICurrentProductListService
    {
		public CurrentProductListService(ICurrentProductListRepository repository) : base(repository)
        {
        }
		public CurrentProductListRepository _repository { get { return _repository as CurrentProductListRepository; } }

	}
}
