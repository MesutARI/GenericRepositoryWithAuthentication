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
	public partial class TerritoryService :GenericService<Territory>, ITerritoryService
    {
		public TerritoryService(ITerritoryRepository repository) : base(repository)
        {
        }
		public TerritoryRepository _repository { get { return _repository as TerritoryRepository; } }

	}
}
