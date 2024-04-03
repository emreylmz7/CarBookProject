using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.ReviewQueries;
using CarBookProject.Application.Features.Mediator.Results.ReviewResults;
using CarBookProject.Application.Interfaces.ReviewInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryResult> 
	{
		private readonly IReviewRepository _repository;
		private readonly IMapper _mapper;

		public GetReviewByIdQueryHandler(IReviewRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetReviewByIdQueryResult> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
		{
			var reviewEntity = await _repository.GetReviewById(request.Id);

			if (reviewEntity == null) // Handle potential null entity
			{
				return null!; // Or throw an exception if a null review is unexpected
			}

			var result = _mapper.Map<GetReviewByIdQueryResult>(reviewEntity);

			return result;
		}
	}
}
