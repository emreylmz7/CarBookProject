using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Commands.CommentCommands;  
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>  
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)  
        {
            var commentEntity = await _repository.GetByIdAsync(request.CommentId);  

            if (commentEntity != null)
            {
                _mapper.Map(request, commentEntity);  

                await _repository.UpdateAsync(commentEntity); 
            }
        }
    }
}
