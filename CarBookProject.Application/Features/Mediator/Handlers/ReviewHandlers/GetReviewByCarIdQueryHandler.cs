using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.ReviewQueries; 
using CarBookProject.Application.Features.Mediator.Results.ReviewResults; 
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewsByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
	{
		private readonly IReviewRepository _repository; 
		private readonly IMapper _mapper;

		public GetReviewsByCarIdQueryHandler(IReviewRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
		{
			var reviewEntities = await _repository.GetReviewsByCarId(request.Id);

			var results = _mapper.Map<List<GetReviewByCarIdQueryResult>>(reviewEntities);

			return results;
		}
	}
}
