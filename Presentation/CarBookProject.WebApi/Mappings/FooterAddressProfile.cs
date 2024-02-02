using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Features.Mediator.Results.FooterAddressResults;

namespace CarBookProject.WebApi.Mappings
{
    public class FooterAddressProfile : Profile
    {
        public FooterAddressProfile()
        {
            CreateMap<CreateFooterAddressCommand, FooterAddress>().ReverseMap();
            CreateMap<RemoveFooterAddressCommand, FooterAddress>().ReverseMap();
            CreateMap<UpdateFooterAddressCommand, FooterAddress>().ReverseMap();
            CreateMap<GetFooterAddressByIdQueryResult, FooterAddress>().ReverseMap();
            CreateMap<GetFooterAddressQueryResult, FooterAddress>().ReverseMap();
        }
    }
}
