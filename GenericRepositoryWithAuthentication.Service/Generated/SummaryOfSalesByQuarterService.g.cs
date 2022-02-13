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
	public partial class SummaryOfSalesByQuarterService :GenericService<SummaryOfSalesByQuarter>, ISummaryOfSalesByQuarterService
    {
		public SummaryOfSalesByQuarterService(ISummaryOfSalesByQuarterRepository repository) : base(repository)
        {
        }
		public SummaryOfSalesByQuarterRepository _repository { get { return _repository as SummaryOfSalesByQuarterRepository; } }

	}
}
