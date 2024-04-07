namespace CarBookProject.Application.Features.Mediator.Results.InvoiceResults
{
    public class GetInvoiceByIdQueryResult
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public decimal Tax { get; set; }
        public DateTime IssueDate { get; set; }
        public string? Description { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DueDate { get; set; }
        public int PaymentId { get; set; }
        public int AppUserId { get; set; }
        public int ReservationId { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? BillingAddress { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CarModel { get; set; }
        public string? CarBrand { get; set; }
        public decimal CarDailyPrice { get; set; }
        public int TotalRentDay { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TransactionFee { get; set; }
    }
}
