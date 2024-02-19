using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.AuthorCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);

            if (author != null)
            {
                // Perform any necessary business logic before deletion (e.g., cascade deletes)
                // ...

                await _repository.DeleteAsync(author);
            }
            else
            {
                // Handle the case where the author is not found (e.g., log a warning)
                // ...
            }
        }
    }
}
