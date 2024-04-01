using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands; 
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CarDescriptionProfile : Profile
    {
        public CarDescriptionProfile()
        {
            CreateMap<CreateCarDescriptionCommand, CarDescription>().ReverseMap();
            CreateMap<RemoveCarDescriptionCommand, CarDescription>().ReverseMap();
            CreateMap<UpdateCarDescriptionCommand, CarDescription>().ReverseMap();
            CreateMap<GetCarDescriptionByIdQueryResult, CarDescription>().ReverseMap();
            CreateMap<GetCarDescriptionByCarIdQueryResult, CarDescription>().ReverseMap();
            CreateMap<GetCarDescriptionQueryResult, CarDescription>().ReverseMap();
        }
    }
}
