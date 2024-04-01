using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarDescriptionCommands
{
    public class RemoveCarDescriptionCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCarDescriptionCommand(int id)
        {
            Id = id;
        }
    }
}
