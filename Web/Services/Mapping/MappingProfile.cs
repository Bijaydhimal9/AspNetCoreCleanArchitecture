using ApplicationCore.DomainModel;
using ApplicationCore.Entities;
using AutoMapper;
using Web.Models.RequestModels;

namespace Web.Services.Mapping
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<EmployeeRequestModel, EmployeeDM>().ReverseMap();
            CreateMap<EmployeeDM, Employee>().ReverseMap();
        }
    }
}
