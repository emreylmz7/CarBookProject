
using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public int? PickupLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }    
        public DateTime PreferredDropOffDate { get; set; }    
        public int Age { get; set; }
        public int LicenseIssuanceYear { get; set; }
        public string? AdditionalComments { get; set; }
        public Location? PickupLocation{ get; set; }
        public Location? DropOffLocation { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
