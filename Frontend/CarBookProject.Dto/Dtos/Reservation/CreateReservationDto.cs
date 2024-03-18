
using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.Reservation
{
    public class CreateReservationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        public int CarId { get; set; }

        [Required(ErrorMessage = "Pickup location is required")]
        public int PickupLocationId { get; set; }

        [Required(ErrorMessage = "Drop-off location is required")]
        public int DropOffLocationId { get; set; }

        [Required(ErrorMessage = "Preferred pickup date is required")]
        [DataType(DataType.Date)]
        public DateTime PreferredPickupDate { get; set; }

        [Required(ErrorMessage = "Preferred drop-off date is required")]
        [DataType(DataType.Date)]
        public DateTime PreferredDropOffDate { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Year of license issuance is required")]
        public int LicenseIssuanceYear { get; set; }

        public string? AdditionalComments { get; set; }
    }
}
