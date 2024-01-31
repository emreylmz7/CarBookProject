using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.CQRS.Commands.ContactCommands;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers 
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            var contactEntity = await _repository.GetByIdAsync(command.Id);

            if (contactEntity != null)
            {
                await _repository.DeleteAsync(contactEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
