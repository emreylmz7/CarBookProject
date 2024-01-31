using AutoMapper;
using CarBook.Domain.Entities; 
using CarBookProject.Application.Features.CQRS.Quaries.ContactQueries; 
using CarBookProject.Application.Features.CQRS.Results.ContactResults;
using CarBookProject.Application.Interfaces;

namespace CarBookProject.Application.Features.CQRS.Handlers.ContactHandlers 
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var contactEntity = await _repository.GetByIdAsync(query.Id);
            var result = _mapper.Map<GetContactByIdQueryResult>(contactEntity);

            return result;
        }
    }
}
