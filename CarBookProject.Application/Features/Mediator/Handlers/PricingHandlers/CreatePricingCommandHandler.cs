using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.PricingCommands; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandlers 
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand> 
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;

        public CreatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var pricingEntity = _mapper.Map<Pricing>(request);
            await _repository.CreateAsync(pricingEntity);
        }
    }
}
