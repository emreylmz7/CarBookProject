using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;  
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers  
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand>  
    {
        private readonly IRepository<Comment> _repository;  
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = _mapper.Map<Comment>(request);  
            await _repository.CreateAsync(commentEntity);
        }
    }
}
