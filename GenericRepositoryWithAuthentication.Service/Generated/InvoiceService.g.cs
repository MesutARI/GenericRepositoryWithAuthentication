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
	public partial class InvoiceService :GenericService<Invoice>, IInvoiceService
    {
		public InvoiceService(IInvoiceRepository repository) : base(repository)
        {
        }
		public InvoiceRepository _repository { get { return _repository as InvoiceRepository; } }

	}
}
