using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.BlogCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public RemoveBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = await _repository.GetByIdAsync(request.Id);

            if (blogEntity != null)
            {
                await _repository.DeleteAsync(blogEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
