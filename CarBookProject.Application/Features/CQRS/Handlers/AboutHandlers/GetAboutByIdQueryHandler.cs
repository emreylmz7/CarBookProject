using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Quaries.AboutQueries;
using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var aboutEntity = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetAboutByIdQueryResult>(aboutEntity);

            return result;
        }
    }
}
