using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.PaymentInterfaces
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsWithInfo();
        Task CreatePayment(Payment payment);
    }
}
