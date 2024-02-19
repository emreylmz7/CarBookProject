using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Features.Mediator.Results.AuthorResults;

namespace CarBookProject.WebApi.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorCommand, Author>().ReverseMap();
            CreateMap<RemoveAuthorCommand, Author>().ReverseMap();
            CreateMap<UpdateAuthorCommand, Author>().ReverseMap();
            CreateMap<GetAuthorByIdQueryResult, Author>().ReverseMap();
            CreateMap<GetAuthorQueryResult, Author>().ReverseMap();
        }
    }
}
