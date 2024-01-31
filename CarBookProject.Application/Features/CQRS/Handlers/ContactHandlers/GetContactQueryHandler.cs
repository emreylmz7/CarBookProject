using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers 
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var contactEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetContactQueryResult>>(contactEntities);

            return results;
        }
    }
}
