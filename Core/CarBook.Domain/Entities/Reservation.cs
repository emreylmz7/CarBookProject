using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int? PickupLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }    
        public DateTime PreferredDropOffDate { get; set; }    
        public string? AdditionalComments { get; set; }
        public Location? PickupLocation{ get; set; }
        public Location? DropOffLocation { get; set; }
        public ReservationStatus Status { get; set; }
		public AppUser? User { get; set; } 
		public List<Payment>? Payments { get; set; } 
		public List<Invoice>? Invoices { get; set; } 
		public decimal TotalCost { get; set; } 
	}
}
