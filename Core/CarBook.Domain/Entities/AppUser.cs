using Microsoft.AspNetCore.Identity;

namespace CarBook.Domain.Entities
{
	public class AppUser : IdentityUser<int>
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? Address { get; set; }
		public byte[]? ProfilePicture { get; set; }
		public DateTime RegistrationDate { get; set; }
		public int Age { get; set; }
		public int LicenseIssuanceYear { get; set; }
		public List<Reservation>? Reservations { get; set; }
		public List<Review>? Reviews { get; set; }
		public List<Invoice>? Invoices { get; set; }
		public bool IsActive { get; set; }
		public List<Payment>? Payments { get; set; }

		//public ICollection<Message> SentMessages { get; set; }
		//public ICollection<Message> ReceivedMessages { get; set; }
		//public ICollection<Notification> Notifications { get; set; }
	}
}
