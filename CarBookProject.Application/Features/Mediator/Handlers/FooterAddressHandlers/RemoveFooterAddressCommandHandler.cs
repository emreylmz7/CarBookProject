using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddressEntity = await _repository.GetByIdAsync(request.Id);

            if (footerAddressEntity != null)
            {
                await _repository.DeleteAsync(footerAddressEntity);
            }
            // Optionally, you can handle the case when the entity with the given ID is not found.
        }
    }
}
