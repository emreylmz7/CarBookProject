using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;
        private readonly IMapper _mapper;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carDescriptionEntity = await _repository.GetCarDescriptionByCarId(request.Id);
            var result = _mapper.Map<GetCarDescriptionByCarIdQueryResult>(carDescriptionEntity);

            return result;
        }
    }
}
