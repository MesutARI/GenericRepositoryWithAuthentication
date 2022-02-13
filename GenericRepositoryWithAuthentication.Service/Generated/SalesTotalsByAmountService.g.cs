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
	public partial class SalesTotalsByAmountService :GenericService<SalesTotalsByAmount>, ISalesTotalsByAmountService
    {
		public SalesTotalsByAmountService(ISalesTotalsByAmountRepository repository) : base(repository)
        {
        }
		public SalesTotalsByAmountRepository _repository { get { return _repository as SalesTotalsByAmountRepository; } }

	}
}
