using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBookProject.Application.Features.Mediator.Results.CarPricingResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CarPricingProfile : Profile
    {
        public CarPricingProfile()
        {
            CreateMap<CreateCarPricingCommand, CarPricing>().ReverseMap(); 
            CreateMap<RemoveCarPricingCommand, CarPricing>().ReverseMap(); 
            CreateMap<UpdateCarPricingCommand, CarPricing>().ReverseMap();

            CreateMap<CarPricing, GetCarPricingByIdQueryResult>()
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car!.CoverImageUrl))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Car!.CarId))
                .ForMember(dest => dest.PricingId, opt => opt.MapFrom(src => src.PricingId))
                .ReverseMap();

            CreateMap<CarPricing, GetCarPricingByCarIdQueryResult>()
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car!.CoverImageUrl))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name))
                .ForMember(dest => dest.PricingId, opt => opt.MapFrom(src => src.PricingId))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Car!.CarId))
                .ReverseMap();

            CreateMap<CarPricing, GetCarPricingQueryResult>()
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car!.CoverImageUrl))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PricingId, opt => opt.MapFrom(src => src.PricingId))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Car!.CarId))
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name))
                .ReverseMap();

            CreateMap<CarPricing, GetCarPricingWithCarsQueryResult>()
                .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car!.CoverImageUrl))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.Car!.CarId))
                .ForMember(dest => dest.PricingId, opt => opt.MapFrom(src => src.PricingId))
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing!.Name))
                .ReverseMap();
        }
    }
}
