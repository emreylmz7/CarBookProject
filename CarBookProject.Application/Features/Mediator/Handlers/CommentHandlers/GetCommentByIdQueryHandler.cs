using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;  
using CarBookProject.Application.Features.Mediator.Results.CommentResults;  
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers  
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult> 
    {
        private readonly IRepository<Comment> _repository;  
        private readonly IMapper _mapper;

        public GetCommentByIdQueryHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var commentEntity = await _repository.GetByIdAsync(request.Id);  
            var result = _mapper.Map<GetCommentByIdQueryResult>(commentEntity);  

            return result;
        }
    }
}
