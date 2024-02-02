using CarBookProject.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery : IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
