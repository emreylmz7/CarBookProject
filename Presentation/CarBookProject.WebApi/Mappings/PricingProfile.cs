using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.PricingCommands;
using CarBookProject.Application.Features.Mediator.Results.PricingResults;

namespace CarBookProject.WebApi.Mappings
{
    public class PricingProfile : Profile
    {
        public PricingProfile()
        {
            CreateMap<CreatePricingCommand, Pricing>().ReverseMap();
            CreateMap<RemovePricingCommand, Pricing>().ReverseMap();
            CreateMap<UpdatePricingCommand, Pricing>().ReverseMap();
            CreateMap<GetPricingByIdQueryResult, Pricing>().ReverseMap();
            CreateMap<GetPricingQueryResult, Pricing>().ReverseMap();
        }
    }
}
