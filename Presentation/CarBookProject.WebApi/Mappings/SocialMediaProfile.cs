using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Features.Mediator.Results.SocialMediaResults;

namespace CarBookProject.WebApi.Mappings
{
    public class SocialMediaProfile : Profile
    {
        public SocialMediaProfile()
        {
            CreateMap<CreateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<RemoveSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaByIdQueryResult, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaQueryResult, SocialMedia>().ReverseMap();
        }
    }
}
