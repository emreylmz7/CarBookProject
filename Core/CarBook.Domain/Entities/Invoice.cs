namespace CarBook.Domain.Entities
{
	public class Invoice
	{
		public int InvoiceId { get; set; }
		public decimal Amount { get; set; } // Fatura tutarı
		public DateTime IssueDate { get; set; } // Fatura tarihi
		public string? Description { get; set; } // Fatura açıklaması
		public bool IsPaid { get; set; } // Fatura ödendi mi?
		public DateTime DueDate { get; set; } // Fatura ödeme son tarihi
		public int PaymentId { get; set; } // Faturaya bağlı olan ödemenin kimliği
		public Payment? Payment { get; set; } // Faturaya bağlı olan ödeme
		public AppUser? User { get; set; } // Faturanın ilişkilendirildiği kullanıcı
		public int ReservationId { get; set; } // Faturanın ilişkilendirildiği araba rezervasyonunun kimliği
		public Reservation? Reservation { get; set; } // Faturanın ilişkilendirildiği araba rezervasyonu
		public string? BillingAddress { get; set; } // Fatura adresi
		public string? TaxNumber { get; set; } // Vergi numarası
		public string? InvoiceNumber { get; set; } // Fatura numarası
		public DateTime PaymentDate { get; set; } // Ödeme tarihi
		public string? PaymentMethod { get; set; } // Ödeme yöntemi
	}
}
