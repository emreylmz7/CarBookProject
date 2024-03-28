using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Features.Mediator.Results.CarFeatureResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CarFeatureProfile : Profile
    {
        public CarFeatureProfile()
        {
            CreateMap<CreateCarFeatureCommand, CarFeature>().ReverseMap();
            CreateMap<RemoveCarFeatureCommand, CarFeature>().ReverseMap();
            CreateMap<UpdateCarFeatureCommand, CarFeature>().ReverseMap();
            CreateMap<CarFeature, GetCarFeatureQueryResult>().ReverseMap();
            CreateMap<CarFeature, GetCarFeatureByIdQueryResult>().ReverseMap();

            CreateMap<CarFeature, GetCarFeatureByCarIdQueryResult>()
                .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(src => src.Feature!.Name))
                .ReverseMap();
        }
    }
}
