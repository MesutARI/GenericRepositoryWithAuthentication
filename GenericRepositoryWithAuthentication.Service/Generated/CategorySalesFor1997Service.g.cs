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
	public partial class CategorySalesFor1997Service :GenericService<CategorySalesFor1997>, ICategorySalesFor1997Service
    {
		public CategorySalesFor1997Service(ICategorySalesFor1997Repository repository) : base(repository)
        {
        }
		public CategorySalesFor1997Repository _repository { get { return _repository as CategorySalesFor1997Repository; } }

	}
}
