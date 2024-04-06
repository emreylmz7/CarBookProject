using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.AppUserCommands;

namespace CarBookProject.WebApi.Mappings
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<UpdateAppUserCommand, AppUser>().ReverseMap();
        }
    }
}
