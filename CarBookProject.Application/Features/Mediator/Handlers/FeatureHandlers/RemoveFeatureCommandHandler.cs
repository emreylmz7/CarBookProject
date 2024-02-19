using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FeatureCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
    {
        private readonly IRepository<Feature> _repository;

        public RemoveFeatureCommandHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
        {
            var featureEntity = await _repository.GetByIdAsync(request.Id);

            if (featureEntity != null)
            {
                await _repository.DeleteAsync(featureEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
