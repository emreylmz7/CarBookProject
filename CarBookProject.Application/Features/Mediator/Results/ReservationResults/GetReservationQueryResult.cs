using CarBook.Domain.Entities;

namespace CarBookProject.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationQueryResult
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public string? AdditionalComments { get; set; }
		public int AppUserId { get; set; }
		public decimal TotalCost { get; set; }


	}
}
