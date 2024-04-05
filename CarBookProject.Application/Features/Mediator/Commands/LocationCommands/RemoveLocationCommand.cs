using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveLocationCommand(int id)
        {
            Id = id;
        }
    }
}
