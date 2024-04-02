namespace CarBook.Domain.Entities
{
	public class Payment
	{
		public int PaymentId { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public AppUser? User { get; set; }
		public int CarReservationId { get; set; }
		public Reservation? Reservation { get; set; }
		public List<Invoice>? Invoices { get; set; }
	}
}
