// 
// This is an auto generated file. 
// Do not make manual change
//  

using GenericRepositoryWithAuthentication.Data.Contexts;
using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;


namespace GenericRepositoryWithAuthentication.Data.Repositories
{
	public partial class SalesByCategoryRepository : GenericRepository<SalesByCategory>, ISalesByCategoryRepository
    {
		public SalesByCategoryRepository(NorthwindContext context) : base(context)
        {
        }
		public NorthwindContext _context { get { return _context as NorthwindContext; } }
	}
}
