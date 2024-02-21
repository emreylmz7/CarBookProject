using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.TagCloudCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class RemoveTagCloudCommandHandler : IRequestHandler<RemoveTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public RemoveTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveTagCloudCommand request, CancellationToken cancellationToken)
        {
            var tagCloudEntity = await _repository.GetByIdAsync(request.Id);

            if (tagCloudEntity != null)
            {
                await _repository.DeleteAsync(tagCloudEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
