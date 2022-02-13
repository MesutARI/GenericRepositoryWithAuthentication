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
	public partial class EmployeeTerritoryService :GenericService<EmployeeTerritory>, IEmployeeTerritoryService
    {
		public EmployeeTerritoryService(IEmployeeTerritoryRepository repository) : base(repository)
        {
        }
		public EmployeeTerritoryRepository _repository { get { return _repository as EmployeeTerritoryRepository; } }

	}
}
