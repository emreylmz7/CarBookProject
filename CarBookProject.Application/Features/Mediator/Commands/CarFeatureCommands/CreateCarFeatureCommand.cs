using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureCommand : IRequest
    {
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
