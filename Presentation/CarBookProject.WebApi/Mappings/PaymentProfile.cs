using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.PaymentCommands; 
using CarBookProject.Application.Features.Mediator.Results.PaymentResults;

namespace CarBookProject.WebApi.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<CreatePaymentCommand, Payment>().ReverseMap();
            CreateMap<RemovePaymentCommand, Payment>().ReverseMap();
            CreateMap<UpdatePaymentCommand, Payment>().ReverseMap();
            CreateMap<GetPaymentByIdQueryResult, Payment>().ReverseMap();
            CreateMap<GetPaymentQueryResult, Payment>().ReverseMap();
        }
    }
}
