using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Results.BrandResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetBrandQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var brandEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetBrandQueryResult>>(brandEntities);

            return results;
        }
    }
}
