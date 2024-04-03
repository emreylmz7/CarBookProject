using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.ReviewQueries;
using CarBookProject.Application.Features.Mediator.Results.ReviewResults;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewsQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>  
	{
		private readonly IReviewRepository _repository;
		private readonly IMapper _mapper;

		public GetReviewsQueryHandler(IReviewRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
		{
			var reviewEntities = await _repository.GetAllReviews();

			var results = _mapper.Map<List<GetReviewQueryResult>>(reviewEntities);

			return results;
		}
	}
}
