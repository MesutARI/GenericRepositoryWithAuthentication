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
	public partial class ProductService :GenericService<Product>, IProductService
    {
		public ProductService(IProductRepository repository) : base(repository)
        {
        }
		public ProductRepository _repository { get { return _repository as ProductRepository; } }

	}
}
