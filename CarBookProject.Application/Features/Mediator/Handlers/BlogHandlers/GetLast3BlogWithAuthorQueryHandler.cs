using AutoMapper;
using CarBookProject.Application.Features.Mediator.Queries.BlogQueries;
using CarBookProject.Application.Features.Mediator.Results.BlogResults;
using CarBookProject.Application.Interfaces.BlogInterfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public GetLast3BlogWithAuthorQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetLast3BlogQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWihtAuthors(); 
            var results = _mapper.Map<List<GetLast3BlogQueryResult>>(values);
            return results;
        }
    }
}
