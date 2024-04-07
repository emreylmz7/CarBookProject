using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.InvoiceInterfaces
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetInvoicesByPaymentId(int id);
        Task<Invoice> GetInvoiceById(int id);
        Task<List<Invoice>> GetInvoices();
    }
}
