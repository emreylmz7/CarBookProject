using CarBookProject.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
