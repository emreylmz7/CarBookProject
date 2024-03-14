using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands
{
    public class CreateDropOffLocationCommand : IRequest
    {
        public string? Name { get; set; }
    }
}
