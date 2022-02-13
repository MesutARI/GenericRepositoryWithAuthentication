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
	public partial class EmployeeService :GenericService<Employee>, IEmployeeService
    {
		public EmployeeService(IEmployeeRepository repository) : base(repository)
        {
        }
		public EmployeeRepository _repository { get { return _repository as EmployeeRepository; } }

	}
}
