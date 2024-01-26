using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BannerCommands;
using CarBookProject.Application.Features.CQRS.Results.BannerResults;

namespace CarBookProject.WebApi.Mappings
{
    public class BannerProfile : Profile
    {
        public BannerProfile() 
        {
            CreateMap<CreateBannerCommand, Banner>().ReverseMap();
            CreateMap<RemoveBannerCommand, Banner>().ReverseMap();
            CreateMap<UpdateBannerCommand, Banner>().ReverseMap();
            CreateMap<GetBannerByIdQueryResult, Banner>().ReverseMap();
            CreateMap<GetBannerQueryResult, Banner>().ReverseMap();
        }
    }
}
