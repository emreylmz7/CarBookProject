using MediatR;

namespace CarBookProject.Application.Features.Mediator.Commands.ReservationCommands
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public string? AdditionalComments { get; set; }
		public int AppUserId { get; set; }
	}
}
