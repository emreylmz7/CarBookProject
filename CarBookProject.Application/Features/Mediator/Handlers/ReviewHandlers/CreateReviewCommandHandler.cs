using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.ReviewCommands;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.ReviewHandlers
{
	public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand> 
	{
		private readonly IRepository<Review> _repository;
		private readonly IMapper _mapper;

		public CreateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
		{
			var reviewEntity = _mapper.Map<Review>(request); 
			await _repository.CreateAsync(reviewEntity);
		}
	}
}
