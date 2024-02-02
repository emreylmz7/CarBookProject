using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.FeatureCommands
{
    public class CreateFeatureCommand : IRequest
    {
        public string? Name { get; set; }
    }
}
