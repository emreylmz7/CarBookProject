using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.CQRS.Results.AboutResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IMapper _mapper;

        public GetAboutQueryHandler(IRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutQueryResult>> Handle()
        {
            var aboutEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetAboutQueryResult>>(aboutEntities);

            return results;
        }
    }
}
