using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class RemoveCarFeatureCommandHandler : IRequestHandler<RemoveCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public RemoveCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeatureEntity = await _repository.GetByIdAsync(request.Id);

            if (carFeatureEntity != null)
            {
                await _repository.DeleteAsync(carFeatureEntity);
            }
            // İsteğe bağlı olarak, verilen ID'ye sahip araç özelliğinin bulunamadığı durumu işleyebilirsiniz.
        }
    }
}
