using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.InvoiceInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.InvoiceRepositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CarBookContext _context;

        public InvoiceRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<Invoice> GetInvoiceById(int id)
        {
            var invoice = _context.Invoices
                .Include(x => x.Payment)
                .Include(x => x.AppUser)
                .Include(x => x.Reservation)
                .ThenInclude(x => x!.Car)
                .ThenInclude(x => x!.Brand)
                .Where(x => x.InvoiceId == id)
                .FirstOrDefaultAsync();
            
            return invoice!;
        }

        public Task<List<Invoice>> GetInvoices()
        {
            var invoices = _context.Invoices
                .Include(x => x.Payment)
                .Include(x => x.AppUser)
                .Include(x => x.Reservation)
                .ThenInclude(x => x!.Car)
                .ThenInclude(x => x!.Brand)
                .ToListAsync();

            return invoices;
        }

        public Task<List<Invoice>> GetInvoicesByPaymentId(int id)
        {
            var invoices = _context.Invoices
                .Include(x => x.Payment)
                .Include(x => x.AppUser)
                .Include(x => x.Reservation)
                .ThenInclude(x => x!.Car)
                .ThenInclude(x => x!.Brand)
                .Where(x => x.PaymentId == id)
                .ToListAsync();

            return invoices;
        }
    }
}
