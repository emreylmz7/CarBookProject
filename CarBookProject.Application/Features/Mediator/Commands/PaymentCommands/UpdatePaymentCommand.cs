using CarBook.Domain.Enums;
using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.PaymentCommands
{
    public class UpdatePaymentCommand : IRequest
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int AppUserId { get; set; }
        public int ReservationId { get; set; }
        public PaymentStatus Status { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal TransactionFee { get; set; }
    }
}
