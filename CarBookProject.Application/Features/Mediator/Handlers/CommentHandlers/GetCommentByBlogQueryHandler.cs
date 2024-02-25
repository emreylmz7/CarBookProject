using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.CommentQueries;
using CarBookProject.Application.Features.Mediator.Results.CommentResults;
using CarBookProject.Application.Interfaces.CommentInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentByBlogQueryHandler : IRequestHandler<GetCommentsByBlogQuery, List<GetCommentsByBlogResult>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public GetCommentByBlogQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentsByBlogResult>> Handle(GetCommentsByBlogQuery request, CancellationToken cancellationToken)
        {
            var commentEntities = await _repository.GetCommentByBlogId(request.Id);

            var results = _mapper.Map<List<GetCommentsByBlogResult>>(commentEntities);

            return results;
        }
    }
}
