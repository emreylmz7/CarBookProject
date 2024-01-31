using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.CQRS.Commands.ContactCommands; 
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers 
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            var contactEntity = await _repository.GetByIdAsync(command.ContactId); 

            if (contactEntity != null)
            {
                _mapper.Map(command, contactEntity);

                await _repository.UpdateAsync(contactEntity);
            }
        }
    }
}
