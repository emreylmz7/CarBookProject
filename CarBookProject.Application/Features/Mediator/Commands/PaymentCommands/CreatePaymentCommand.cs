using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.PaymentCommands
{
    public class CreatePaymentCommand : IRequest
    {
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public string? ExpiryDate { get; set; }
        public string? CVV { get; set; }
        public int AppUserId { get; set; }
        public int ReservationId { get; set; }
    }
}
