

// 
// This is an auto generated file. 
// Do not make manual change
//  
using AutoMapper;
using GenericRepositoryWithAuthentication.API.DTO;
using GenericRepositoryWithAuthentication.Core.Models;

namespace GenericRepositoryWithAuthentication.API.Mapping
{
	public partial class MappingProfile : Profile
    {
		public MappingProfile()
		{
						
			CreateMap<Category, CategoryDTO>();
			CreateMap<CategoryDTO, Category>();
			
						
			CreateMap<Customer, CustomerDTO>();
			CreateMap<CustomerDTO, Customer>();
			
			
		}
	}
}
