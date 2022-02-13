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
	public partial class ProductSalesFor1997Service :GenericService<ProductSalesFor1997>, IProductSalesFor1997Service
    {
		public ProductSalesFor1997Service(IProductSalesFor1997Repository repository) : base(repository)
        {
        }
		public ProductSalesFor1997Repository _repository { get { return _repository as ProductSalesFor1997Repository; } }

	}
}
