using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CarCommands;
using CarBookProject.Application.Features.CQRS.Results.CarResults;
using System.Linq;

namespace CarBookProject.WebApi.Mappings
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<RemoveCarCommand, Car>().ReverseMap();
            CreateMap<UpdateCarCommand, Car>().ReverseMap();
            CreateMap<GetCarByIdQueryResult, Car>().ReverseMap();
            CreateMap<GetCarQueryResult, Car>().ReverseMap();

            CreateMap<Car, GetCarWithBrandQueryResult>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.HourlyPrice, opt => opt.MapFrom(src => src.CarPricing != null && src.CarPricing.Any() ? src.CarPricing.First().Amount : 0))
                .ReverseMap();
        }
    }
}
