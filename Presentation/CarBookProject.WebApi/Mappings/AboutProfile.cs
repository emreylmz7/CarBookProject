using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.AboutCommands;
using CarBookProject.Application.Features.CQRS.Results.AboutResults;

namespace CarBookProject.WebApi.Mappings
{
    public class AboutProfile : Profile
    {
        public AboutProfile() 
        {
            CreateMap<CreateAboutCommand, About>().ReverseMap();
            CreateMap<RemoveAboutCommand, About>().ReverseMap();
            CreateMap<UpdateAboutCommand, About>().ReverseMap();
            CreateMap<GetAboutByIdQueryResult, About>().ReverseMap();
            CreateMap<GetAboutQueryResult, About>().ReverseMap();
        }
    }
}
