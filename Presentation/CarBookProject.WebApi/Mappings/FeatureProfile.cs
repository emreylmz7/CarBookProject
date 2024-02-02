using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults; 

namespace CarBookProject.WebApi.Mappings
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<CreateFeatureCommand, Feature>().ReverseMap();
            CreateMap<RemoveFeatureCommand, Feature>().ReverseMap();
            CreateMap<UpdateFeatureCommand, Feature>().ReverseMap();
            CreateMap<GetFeatureByIdQueryResult, Feature>().ReverseMap();
            CreateMap<GetFeatureQueryResult, Feature>().ReverseMap();
        }
    }
}
