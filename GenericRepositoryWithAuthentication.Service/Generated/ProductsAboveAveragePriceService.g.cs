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
	public partial class ProductsAboveAveragePriceService :GenericService<ProductsAboveAveragePrice>, IProductsAboveAveragePriceService
    {
		public ProductsAboveAveragePriceService(IProductsAboveAveragePriceRepository repository) : base(repository)
        {
        }
		public ProductsAboveAveragePriceRepository _repository { get { return _repository as ProductsAboveAveragePriceRepository; } }

	}
}
