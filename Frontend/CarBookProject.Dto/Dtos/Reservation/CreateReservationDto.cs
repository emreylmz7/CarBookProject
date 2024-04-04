using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.Reservation
{
    public class CreateReservationDto
    {
        public int CarId { get; set; }
        public int AppUserId { get; set; }

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
        public string? AdditionalComments { get; set; }
    }
}
