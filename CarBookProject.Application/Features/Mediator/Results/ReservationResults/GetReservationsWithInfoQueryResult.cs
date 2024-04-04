using CarBook.Domain.Enums;

namespace CarBookProject.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationsWithInfoQueryResult
    {
        public int ReservationId { get; set; }
        public string? CarName { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public string? PickupLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public string? DropOffLocation { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public int TotalRentDay { get; set; }
        public string? AdditionalComments { get; set; }
        public ReservationStatus Status { get; set; }
		public int AppUserId { get; set; }
		public decimal TotalCost { get; set; }

	}
}
