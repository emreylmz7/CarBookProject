using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand : IRequest
    {
        public int CarId { get; set; }
        public string? Details { get; set; }
    }
}
