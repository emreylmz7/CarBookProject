using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class RemoveCarPricingCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCarPricingCommand(int id)
        {
            Id = id;
        }
    }
}
