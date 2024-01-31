using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.CategoryCommands;
using CarBookProject.Application.Features.CQRS.Results.CategoryResults;

namespace CarBookProject.WebApi.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<RemoveCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<GetCategoryByIdQueryResult, Category>().ReverseMap();
            CreateMap<GetCategoryQueryResult, Category>().ReverseMap();
        }
    }
}
