using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.PricingQueries;
using CarBookProject.Application.Features.Mediator.Results.PricingResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingsQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;
        private readonly IMapper _mapper;

        public GetPricingsQueryHandler(IRepository<Pricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var pricingEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetPricingQueryResult>>(pricingEntities);

            return results;
        }
    }
}
