using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands; 
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults; 

namespace CarBookProject.WebApi.Mappings
{
    public class TagCloudProfile : Profile
    {
        public TagCloudProfile()
        {
            CreateMap<CreateTagCloudCommand, TagCloud>().ReverseMap();
            CreateMap<RemoveTagCloudCommand, TagCloud>().ReverseMap();
            CreateMap<UpdateTagCloudCommand, TagCloud>().ReverseMap();
            CreateMap<GetTagCloudByIdQueryResult, TagCloud>().ReverseMap();
            CreateMap<GetTagCloudQueryResult, TagCloud>().ReverseMap();
        }
    }
}
