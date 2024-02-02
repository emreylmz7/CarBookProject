using AutoMapper;
using CarBook.Domain.Entities;
using CarBookProject.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarBookProject.Application.Features.Mediator.Results.FeatureResults;
using CarBookProject.Application.Features.Mediator.Results.FooterAddressResults;
using CarBookProject.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;
        private readonly IMapper _mapper;
        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var footerAddressEntities = await _repository.GetAllAsync();
            var results = _mapper.Map<List<GetFooterAddressQueryResult>>(footerAddressEntities);

            return results;
        }
    }
}
