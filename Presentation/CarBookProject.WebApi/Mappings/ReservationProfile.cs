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
            CreateMap<GetReservationQueryResult, Reservation>().ReverseMap();

            CreateMap<Reservation, GetReservationByIdQueryResult>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Car!.Brand.Name))
                .ForMember(dest => dest.PickupLocation, opt => opt.MapFrom(src => src.PickupLocation!.Name))
                .ForMember(dest => dest.DropOffLocation, opt => opt.MapFrom(src => src.DropOffLocation!.Name))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDay(src)))
                .ReverseMap();

            CreateMap<Reservation, GetReservationsWithInfoQueryResult>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PickupLocation, opt => opt.MapFrom(src => src.PickupLocation!.Name))
                .ForMember(dest => dest.DropOffLocation, opt => opt.MapFrom(src => src.DropOffLocation!.Name))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDay(src)))
                .ReverseMap();

            CreateMap<Reservation, GetReservationsByUserIdQueryResult>()
                .ForMember(dest => dest.CarName, opt => opt.MapFrom(src => src.Car!.Model))
                .ForMember(dest => dest.PickupLocation, opt => opt.MapFrom(src => src.PickupLocation!.Name))
                .ForMember(dest => dest.DropOffLocation, opt => opt.MapFrom(src => src.DropOffLocation!.Name))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDay(src)))
                .ReverseMap();
        }

        private int CalculateTotalRentDay(Reservation reservation)
        {
            return (reservation.PreferredDropOffDate.Date - reservation.PreferredPickupDate.Date).Days;
        }

    }
}
