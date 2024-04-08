using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.AppUserCommands;
using CarBookProject.Application.Features.Mediator.Results.AppUserResults;

namespace CarBookProject.WebApi.Mappings
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<UpdateAppUserCommand, AppUser>().ReverseMap();
            CreateMap<GetAppUsersQueryResult, AppUser>().ReverseMap();
        }
    }
}
