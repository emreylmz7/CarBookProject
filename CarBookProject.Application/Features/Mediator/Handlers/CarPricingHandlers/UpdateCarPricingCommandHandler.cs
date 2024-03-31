using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarPricingHandlers 
{
    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand> 
    {
        private readonly IRepository<CarPricing> _repository; 
        private readonly IMapper _mapper;

        public UpdateCarPricingCommandHandler(IRepository<CarPricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var carPricingEntity = await _repository.GetByIdAsync(request.CarPricingId); 

            if (carPricingEntity != null)
            {
                _mapper.Map(request, carPricingEntity);

                await _repository.UpdateAsync(carPricingEntity); 
            }
           
        }
    }
}
