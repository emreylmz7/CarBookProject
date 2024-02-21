using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.BlogCommands;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;

namespace CarBookProject.WebApi.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<CreateBlogCommand, Blog>().ReverseMap();
            CreateMap<RemoveBlogCommand, Blog>().ReverseMap();
            CreateMap<UpdateBlogCommand, Blog>().ReverseMap();
            CreateMap<GetBlogByIdQueryResult, Blog>().ReverseMap();
            CreateMap<GetBlogQueryResult, Blog>().ReverseMap();

            CreateMap<Blog, GetLast3BlogQueryResult > ()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
                .ReverseMap();

            CreateMap<Blog, GetAllBlogsWithAuthorQueryResult>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.Name))
                .ReverseMap();

        }
    }
}
