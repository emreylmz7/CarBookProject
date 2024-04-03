using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand> 
	{
		private readonly IRepository<Review> _repository;
		private readonly IMapper _mapper;

		public UpdateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
		{
			var ReviewEntity = await _repository.GetByIdAsync(request.ReviewId);

			if (ReviewEntity != null)
			{
				_mapper.Map(request, ReviewEntity);

				await _repository.UpdateAsync(ReviewEntity);
			}
		}
	}
}
