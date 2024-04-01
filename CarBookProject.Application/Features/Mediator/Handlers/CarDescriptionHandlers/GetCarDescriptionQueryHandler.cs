using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries; 
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionQueryHandler : IRequestHandler<GetCarDescriptionQuery, List<GetCarDescriptionQueryResult>>
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly IMapper _mapper;

        public GetCarDescriptionQueryHandler(IRepository<CarDescription> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarDescriptionQueryResult>> Handle(GetCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var carDescriptionEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetCarDescriptionQueryResult>>(carDescriptionEntities);

            return results;
        }
    }
}
