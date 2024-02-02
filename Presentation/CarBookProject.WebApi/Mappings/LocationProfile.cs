using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.LocationCommands; 
using CarBookProject.Application.Features.Mediator.Results.LocationResults; 

namespace CarBookProject.WebApi.Mappings
{ 
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<CreateLocationCommand, Location>().ReverseMap(); 
            CreateMap<RemoveLocationCommand, Location>().ReverseMap(); 
            CreateMap<UpdateLocationCommand, Location>().ReverseMap(); 
            CreateMap<GetLocationByIdQueryResult, Location>().ReverseMap(); 
            CreateMap<GetLocationQueryResult, Location>().ReverseMap(); 
        }
    }
}
