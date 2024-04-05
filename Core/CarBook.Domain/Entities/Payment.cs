using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
	public class Payment
	{
		public int PaymentId { get; set; }
		public decimal Amount { get; set; }
		public DateTime PaymentDate { get; set; }
		public int AppUserId { get; set; }
		public AppUser? AppUser { get; set; }
		public int ReservationId { get; set; }
		public Reservation? Reservation { get; set; }
		public List<Invoice>? Invoices { get; set; }
		public PaymentStatus Status { get; set; }
		public PaymentMethod Method { get; set; } 
		public decimal TransactionFee { get; set; }

		public Payment()
		{
			Status = PaymentStatus.Pending;
			Method = PaymentMethod.CreditCard;
		}
	}
}
