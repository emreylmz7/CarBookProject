using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class RemoveReviewCommandHandler : IRequestHandler<RemoveReviewCommand> 
	{
		private readonly IRepository<Review> _repository;

		public RemoveReviewCommandHandler(IRepository<Review> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveReviewCommand request, CancellationToken cancellationToken)
		{
			var carFeatureEntity = await _repository.GetByIdAsync(request.Id);

			if (carFeatureEntity != null)
			{
				await _repository.DeleteAsync(carFeatureEntity);
			}
		}
	}
}
