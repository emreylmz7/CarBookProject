using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers 
{
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand command)
        {
            var contactEntity = _mapper.Map<Contact>(command);
            await _repository.CreateAsync(contactEntity);
        }
    }
}
