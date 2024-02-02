using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.PricingCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var pricingEntity = await _repository.GetByIdAsync(request.PricingId);

            if (pricingEntity != null)
            {
                _mapper.Map(request, pricingEntity);

                await _repository.UpdateAsync(pricingEntity);
            }
        }
    }
}
