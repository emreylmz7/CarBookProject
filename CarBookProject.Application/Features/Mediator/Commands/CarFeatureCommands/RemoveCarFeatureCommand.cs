using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class RemoveCarFeatureCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCarFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
