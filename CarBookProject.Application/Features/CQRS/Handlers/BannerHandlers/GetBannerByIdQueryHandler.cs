using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Quaries.BannerQueries;
using CarBookProject.Application.Features.CQRS.Results.BannerResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IMapper _mapper;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var bannerEntity = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetBannerByIdQueryResult>(bannerEntity);

            return result;
        }
    }
}
