using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ServiceQueries; 
using CarBookProject.Application.Features.Mediator.Results.ServiceResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServicesQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>> 
    {
        private readonly IRepository<Service> _repository; 
        private readonly IMapper _mapper;

        public GetServicesQueryHandler(IRepository<Service> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var serviceEntities = await _repository.GetAllAsync(); 
            var results = _mapper.Map<List<GetServiceQueryResult>>(serviceEntities); 

            return results;
        }
    }
}
