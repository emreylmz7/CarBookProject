using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;
        private readonly IMapper _mapper;

        public UpdateCarFeatureCommandHandler(IRepository<CarFeature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeatureEntity = await _repository.GetByIdAsync(request.CarFeatureId);

            if (carFeatureEntity != null)
            {
                _mapper.Map(request, carFeatureEntity);

                await _repository.UpdateAsync(carFeatureEntity);
            }
        }
    }
}
