using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBookProject.Application.Features.Mediator.Results.FooterAddressResults;
using CarBookProject.Application.Interfaces;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;
        private readonly IMapper _mapper;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var footerAddressEntity = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetFooterAddressByIdQueryResult>(footerAddressEntity);

            return result;
        }
    }
}
