// 
// This is an auto generated file. 
// Do not make manual change
//  

using GenericRepositoryWithAuthentication.Data.Contexts;
using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;


namespace GenericRepositoryWithAuthentication.Data.Repositories
{
	public partial class ProductSalesFor1997Repository : GenericRepository<ProductSalesFor1997>, IProductSalesFor1997Repository
    {
		public ProductSalesFor1997Repository(NorthwindContext context) : base(context)
        {
        }
		public NorthwindContext _context { get { return _context as NorthwindContext; } }
	}
}
