using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReservationCommands;
using CarBookProject.Application.Features.Mediator.Results.ReservationResults;

namespace CarBookProject.WebApi.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationCommand, Reservation>().ReverseMap();
            CreateMap<RemoveReservationCommand, Reservation>().ReverseMap();
            CreateMap<UpdateReservationCommand, Reservation>().ReverseMap();
            CreateMap<GetReservationByIdQueryResult, Reservation>().ReverseMap();
            CreateMap<GetReservationQueryResult, Reservation>().ReverseMap();
        }
    }
}
