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

            var invoice = new Invoice
            {
                Amount = payment.Amount,
                IssueDate = DateTime.Now,
                Description = reservation.AdditionalComments,
                IsPaid = true,
                DueDate = payment.PaymentDate.AddDays(30),
                PaymentId = payment.PaymentId,
                AppUserId = payment.AppUserId,
                ReservationId = payment.ReservationId,
                BillingAddress = "Cumhuriyet Caddesi Merkez Sokak No: 17 Kumluca/Antalya",
                TaxNumber = "1234567890",
                InvoiceNumber = "INV-CARBOOK",
                PaymentDate = payment.PaymentDate,
                PaymentMethod = "Credit Card"
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public Task<List<Payment>> GetPaymentsByUserId(int id)
        {
            var payments = _context.Payments.Where(x => x.AppUserId == id).ToListAsync();
            return payments;
        }

        public Task<List<Payment>> GetPaymentsWithInfo()
        {
            var payments = _context.Payments
                                    .Include(x=>x.AppUser)
                                    .ToListAsync();
            return payments;
        }
    }
}
