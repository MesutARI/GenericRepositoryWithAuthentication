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
	public partial class SummaryOfSalesByYearService :GenericService<SummaryOfSalesByYear>, ISummaryOfSalesByYearService
    {
		public SummaryOfSalesByYearService(ISummaryOfSalesByYearRepository repository) : base(repository)
        {
        }
		public SummaryOfSalesByYearRepository _repository { get { return _repository as SummaryOfSalesByYearRepository; } }

	}
}
