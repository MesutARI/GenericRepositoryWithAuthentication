// 
// This is an auto generated file. 
// Do not make manual change
//  

using GenericRepositoryWithAuthentication.Data.Contexts;
using GenericRepositoryWithAuthentication.Core.Models;
using GenericRepositoryWithAuthentication.Core.Repositories;


namespace GenericRepositoryWithAuthentication.Data.Repositories
{
	public partial class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
    {
		public ShipperRepository(NorthwindContext context) : base(context)
        {
        }
		public NorthwindContext _context { get { return _context as NorthwindContext; } }
	}
}
