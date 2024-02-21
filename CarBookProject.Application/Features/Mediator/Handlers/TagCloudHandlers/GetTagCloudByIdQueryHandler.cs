using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.Mediator.Queries.TagCloudQueries; 
using CarBookProject.Application.Features.Mediator.Results.TagCloudResults; 
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var tagCloudEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetTagCloudByIdQueryResult>(tagCloudEntity);

            return result;
        }
    }
}
