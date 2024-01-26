using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.BrandCommands;
using CarBookProject.Application.Features.CQRS.Results.BrandResults;

namespace CarBookProject.WebApi.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<RemoveBrandCommand, Brand>().ReverseMap();
            CreateMap<UpdateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdQueryResult, Brand>().ReverseMap();
            CreateMap<GetBrandQueryResult, Brand>().ReverseMap();
        }
    }
}
