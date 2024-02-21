using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CarPricingProfile : Profile
    {
        public CarPricingProfile()
        {
            CreateMap<CarPricing, GetCarPricingWithCarsQueryResult>()
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car!.CoverImageUrl))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name))
                .ReverseMap();
        }
    }
}
