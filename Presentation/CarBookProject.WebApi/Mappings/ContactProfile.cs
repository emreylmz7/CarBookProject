using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.CQRS.Commands.ContactCommands; 
using CarBookProject.Application.Features.CQRS.Results.ContactResults; 

namespace CarBookProject.WebApi.Mappings
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<CreateContactCommand, Contact>().ReverseMap();
            CreateMap<RemoveContactCommand, Contact>().ReverseMap();
            CreateMap<UpdateContactCommand, Contact>().ReverseMap();
            CreateMap<GetContactByIdQueryResult, Contact>().ReverseMap();
            CreateMap<GetContactQueryResult, Contact>().ReverseMap();
        }
    }
}
