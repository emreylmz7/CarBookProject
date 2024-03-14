using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.DropOffLocationCommands
{
    public class RemoveDropOffLocationCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveDropOffLocationCommand(int id)
        {
            Id = id;
        }
    }
}
