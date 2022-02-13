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
	public partial class ShipperService :GenericService<Shipper>, IShipperService
    {
		public ShipperService(IShipperRepository repository) : base(repository)
        {
        }
		public ShipperRepository _repository { get { return _repository as ShipperRepository; } }

	}
}
