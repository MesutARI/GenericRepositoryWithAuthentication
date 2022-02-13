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
	public partial class RegionService :GenericService<Region>, IRegionService
    {
		public RegionService(IRegionRepository repository) : base(repository)
        {
        }
		public RegionRepository _repository { get { return _repository as RegionRepository; } }

	}
}
