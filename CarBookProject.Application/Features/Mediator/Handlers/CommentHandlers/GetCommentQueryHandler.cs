using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;  
using CarBookProject.Application.Features.Mediator.Results.CommentResults;  
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers  
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>  
    {
        private readonly IRepository<Comment> _repository; 
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var commentEntities = await _repository.GetAllAsync();  

            var results = _mapper.Map<List<GetCommentQueryResult>>(commentEntities);  

            return results;
        }
    }
}
