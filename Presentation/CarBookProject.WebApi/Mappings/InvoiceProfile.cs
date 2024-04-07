using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Results.InvoiceResults; 

namespace CarBookProject.WebApi.Mappings
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, GetInvoiceByIdQueryResult>()
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => 9.85m))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.AppUser!.Name + " " + src.AppUser.Surname))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.AppUser!.Email))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.AppUser!.PhoneNumber))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.AppUser!.Address))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Reservation!.Car!.Model))
                .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Reservation!.Car!.Brand.Name))
                .ForMember(dest => dest.CarDailyPrice, opt => opt.MapFrom(src => GetCarDailyPrice(src)))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDays(src)))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Payment!.Amount + src.Payment.TransactionFee + 9.85m))
                .ForMember(dest => dest.TransactionFee, opt => opt.MapFrom(src => src.Payment!.TransactionFee))
                .ReverseMap();
            CreateMap<Invoice, GetInvoiceByPaymentIdQueryResult>()
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => 9.85m))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.AppUser!.Name + " " + src.AppUser.Surname))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.AppUser!.Email))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.AppUser!.PhoneNumber))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.AppUser!.Address))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Reservation!.Car!.Model))
                .ForMember(dest => dest.CarDailyPrice, opt => opt.MapFrom(src => GetCarDailyPrice(src)))
                .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Reservation!.Car!.Brand.Name))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDays(src)))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Payment!.Amount + src.Payment.TransactionFee + 9.85m))
                .ForMember(dest => dest.TransactionFee, opt => opt.MapFrom(src => src.Payment!.TransactionFee))
                .ReverseMap();
            CreateMap<Invoice, GetInvoiceQueryResult>()
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => 9.85m))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.AppUser!.Name + " " + src.AppUser.Surname))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.AppUser!.Email))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.AppUser!.PhoneNumber))
                .ForMember(dest => dest.CustomerAddress, opt => opt.MapFrom(src => src.AppUser!.Address))
                .ForMember(dest => dest.CarModel, opt => opt.MapFrom(src => src.Reservation!.Car!.Model))
                .ForMember(dest => dest.CarBrand, opt => opt.MapFrom(src => src.Reservation!.Car!.Brand.Name))
                .ForMember(dest => dest.CarDailyPrice, opt => opt.MapFrom(src => GetCarDailyPrice(src)))
                .ForMember(dest => dest.TotalRentDay, opt => opt.MapFrom(src => CalculateTotalRentDays(src)))
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Payment!.Amount + src.Payment.TransactionFee + 9.85m))
                .ForMember(dest => dest.TransactionFee, opt => opt.MapFrom(src => src.Payment!.TransactionFee))
                .ReverseMap();
        }

        private int CalculateTotalRentDays(Invoice src)
        {
            return (src.Reservation!.PreferredDropOffDate - src.Reservation.PreferredPickupDate).Days;
        }

        private decimal GetCarDailyPrice(Invoice src)
        {
            var carPrice = src.Reservation!.Car!.CarPricing!.Where(x => x.PricingId == 3 && x.CarId == src.Reservation.CarId).FirstOrDefault();
            var dailyPrice = carPrice!.Amount;
            return dailyPrice;
        }
    }
}
