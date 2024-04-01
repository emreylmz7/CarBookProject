using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, GetCarDescriptionByIdQueryResult>
    {
        private readonly IRepository<CarDescription> _repository;
        private readonly IMapper _mapper;

        public GetCarDescriptionByIdQueryHandler(IRepository<CarDescription> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarDescriptionByIdQueryResult> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var carDescriptionEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetCarDescriptionByIdQueryResult>(carDescriptionEntity);

            return result;
        }
    }
}
