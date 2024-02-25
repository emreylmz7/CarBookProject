using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentCommand, Comment>().ReverseMap();
            CreateMap<RemoveCommentCommand, Comment>().ReverseMap();
            CreateMap<UpdateCommentCommand, Comment>().ReverseMap();
            CreateMap<GetCommentByIdQueryResult, Comment>().ReverseMap();
            CreateMap<GetCommentQueryResult, Comment>().ReverseMap();
            CreateMap<GetCommentsByBlogResult, Comment>().ReverseMap();
        }
    }
}
