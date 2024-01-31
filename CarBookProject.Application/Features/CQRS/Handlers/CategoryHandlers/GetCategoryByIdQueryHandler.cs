using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Quaries.CategoryQueries;
using CarBookProject.Application.Features.CQRS.Results.CategoryResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var categoryEntity = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetCategoryByIdQueryResult>(categoryEntity);

            return result;
        }
    }
}
