using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.AppUserQueries;
using CarBookProject.Application.Features.Mediator.Results.AppUserResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetAppUsersQueryHandler : IRequestHandler<GetAppUsersQuery, List<GetAppUsersQueryResult>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetAppUsersQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAppUsersQueryResult>> Handle(GetAppUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetAppUsersQueryResult>>(users);

            return results;
        }
    }
}
