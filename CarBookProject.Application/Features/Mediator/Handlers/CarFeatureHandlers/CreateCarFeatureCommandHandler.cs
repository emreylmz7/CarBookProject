using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;
        private readonly IMapper _mapper;

        public CreateCarFeatureCommandHandler(IRepository<CarFeature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var carFeatureEntity = _mapper.Map<CarFeature>(request);
            await _repository.CreateAsync(carFeatureEntity);
        }
    }
}
