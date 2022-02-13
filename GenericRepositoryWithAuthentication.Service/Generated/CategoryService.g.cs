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
	public partial class CategoryService :GenericService<Category>, ICategoryService
    {
		public CategoryService(ICategoryRepository repository) : base(repository)
        {
        }
		public CategoryRepository _repository { get { return _repository as CategoryRepository; } }

	}
}
