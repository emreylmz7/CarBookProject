using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands;
using CarBookProject.Application.Features.Mediator.Results.DropOffLocationResults;

namespace CarBookProject.WebApi.Mappings
{
    public class DropOffLocationProfile : Profile
    {
        public DropOffLocationProfile()
        {
            CreateMap<CreateDropOffLocationCommand, DropOffLocation>().ReverseMap();
            CreateMap<RemoveDropOffLocationCommand, DropOffLocation>().ReverseMap();
            CreateMap<UpdateDropOffLocationCommand, DropOffLocation>().ReverseMap();
            CreateMap<GetDropOffLocationByIdQueryResult, DropOffLocation>().ReverseMap();
            CreateMap<GetDropOffLocationQueryResult, DropOffLocation>().ReverseMap();
        }
    }
}
