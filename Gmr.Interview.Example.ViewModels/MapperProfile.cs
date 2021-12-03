using AutoMapper;
using Gmr.Interview.Example.DomainModels;

namespace Gmr.Interview.Example.ViewModels
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Project, ProjectViewModel>().ReverseMap();
        }
    }
}
