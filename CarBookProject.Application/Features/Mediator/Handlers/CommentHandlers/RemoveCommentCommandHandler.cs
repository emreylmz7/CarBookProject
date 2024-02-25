using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;  
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentCommandHandler : IRequestHandler<RemoveCommentCommand>  
    {
        private readonly IRepository<Comment> _repository;  

        public RemoveCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var commentEntity = await _repository.GetByIdAsync(request.Id);  

            if (commentEntity != null)
            {
                await _repository.DeleteAsync(commentEntity);  
            }
            // Optionally, you can handle the case when the comment with the given ID is not found.
        }
    }
}
