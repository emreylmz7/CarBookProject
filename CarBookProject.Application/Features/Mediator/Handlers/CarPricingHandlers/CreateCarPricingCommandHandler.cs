using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers 
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand> 
    {
        private readonly IRepository<CarPricing> _repository; 
        private readonly IMapper _mapper;

        public CreateCarPricingCommandHandler(IRepository<CarPricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var carPricingEntity = _mapper.Map<CarPricing>(request); 
            await _repository.CreateAsync(carPricingEntity);
        }
    }
}
