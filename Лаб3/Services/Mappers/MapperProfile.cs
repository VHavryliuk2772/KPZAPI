using AutoMapper;
using Domain.Models;
using ViewModels.ProjectDTOs;
using ViewModels.CustomerDTOs;

namespace Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Project, ShortProjectDTO>();

            CreateMap<Project, DetailedProjectDTO>()
                .ForMember(dto => dto.CustomerFullName, g => g.MapFrom(e => e.Customer.FirstName + " " + e.Customer.LastName))
                .ForMember(dto => dto.Type, g => g.MapFrom(e => nameof(e.Type)));

            CreateMap<UpdateCreateProjectDTO, Project>();

            CreateMap<Customer, ShortCustomerDTO>();

            CreateMap<UpdateCreateCustomerDTO, Customer>();
        }
    }
}
