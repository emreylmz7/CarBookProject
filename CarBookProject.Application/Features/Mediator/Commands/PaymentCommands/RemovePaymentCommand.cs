using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.PaymentCommands
{
    public class RemovePaymentCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePaymentCommand(int id)
        {
            Id = id;
        }
    }
}
