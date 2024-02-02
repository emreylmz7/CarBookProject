using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ServiceCommands; 
using CarBookProject.Application.Features.Mediator.Results.ServiceResults; 

namespace CarBookProject.WebApi.Mappings 
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateServiceCommand, Service>().ReverseMap(); 
            CreateMap<RemoveServiceCommand, Service>().ReverseMap(); 
            CreateMap<UpdateServiceCommand, Service>().ReverseMap(); 
            CreateMap<GetServiceByIdQueryResult, Service>().ReverseMap(); 
            CreateMap<GetServiceQueryResult, Service>().ReverseMap();
        }
    }
}
