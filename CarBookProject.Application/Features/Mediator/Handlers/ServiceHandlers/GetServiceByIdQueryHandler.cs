using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.ServiceQueries; 
using CarBookProject.Application.Features.Mediator.Results.ServiceResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ServiceHandlers 
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult> 
    {
        private readonly IRepository<Service> _repository; 
        private readonly IMapper _mapper;

        public GetServiceByIdQueryHandler(IRepository<Service> repository, IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceEntity = await _repository.GetByIdAsync(request.Id); 
            var result = _mapper.Map<GetServiceByIdQueryResult>(serviceEntity); 

            return result;
        }
    }
}
