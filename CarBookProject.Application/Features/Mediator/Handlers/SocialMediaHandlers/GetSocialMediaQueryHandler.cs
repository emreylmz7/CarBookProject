using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarBookProject.Application.Features.Mediator.Results.SocialMediaResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediasQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;

        public GetSocialMediasQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var socialMediaEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetSocialMediaQueryResult>>(socialMediaEntities);

            return results;
        }
    }
}
