using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries; 
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var tagCloudEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetTagCloudQueryResult>>(tagCloudEntities);

            return results;
        }
    }
}
