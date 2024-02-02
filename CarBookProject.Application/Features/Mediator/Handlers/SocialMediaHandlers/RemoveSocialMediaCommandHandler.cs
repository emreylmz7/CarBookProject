using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMediaEntity = await _repository.GetByIdAsync(request.Id);

            if (socialMediaEntity != null)
            {
                await _repository.DeleteAsync(socialMediaEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
