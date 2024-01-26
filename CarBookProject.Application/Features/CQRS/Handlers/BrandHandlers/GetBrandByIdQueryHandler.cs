using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Quaries.BrandQueries;
using CarBookProject.Application.Features.CQRS.Results.BrandResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var brandEntity = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetBrandByIdQueryResult>(brandEntity);

            return result;
        }
    }
}
