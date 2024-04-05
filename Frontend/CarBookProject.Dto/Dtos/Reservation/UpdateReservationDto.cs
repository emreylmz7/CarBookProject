
namespace CarBookProject.Dto.Dtos.Reservation
{
    public class UpdateReservationDto
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public string? AdditionalComments { get; set; }
    }
}
