using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.CarPricingCommands
{
    public class UpdateCarPricingCommand : IRequest
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
