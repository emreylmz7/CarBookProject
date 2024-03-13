using CarBookProject.Application.Features.Mediator.Queries.RentACarQueries;
using CarBookProject.Application.Features.Mediator.Results.RentACarResults;
using CarBookProject.Application.Interfaces.RentACarInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _repository;

        public GetRentACarQueryHandler(IRentACarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);
            return values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId,

            }).ToList();
        }
    }
}
