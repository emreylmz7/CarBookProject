using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using CarBookProject.Application.Interfaces.PaymentInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.PaymentRepositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CarBookContext _context;

        public PaymentRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task CreatePayment(Payment payment)
        {
            payment.Amount = (from r in _context.Reservations
                          where r.ReservationId == payment.ReservationId
                          select r.TotalCost).FirstOrDefault();
            payment.PaymentDate = DateTime.Now;
            payment.Status = PaymentStatus.Completed;
            payment.Method = PaymentMethod.CreditCard;
            payment.TransactionFee = 16;
            
            var reservation = await _context.Reservations.Where(x=> x.ReservationId == payment.ReservationId).FirstOrDefaultAsync();
            reservation!.Status = ReservationStatus.Completed;

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetPaymentsWithInfo()
        {
            throw new NotImplementedException();
        }
    }
}
