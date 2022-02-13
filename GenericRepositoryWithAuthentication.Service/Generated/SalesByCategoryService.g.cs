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
	public partial class SalesByCategoryService :GenericService<SalesByCategory>, ISalesByCategoryService
    {
		public SalesByCategoryService(ISalesByCategoryRepository repository) : base(repository)
        {
        }
		public SalesByCategoryRepository _repository { get { return _repository as SalesByCategoryRepository; } }

	}
}
