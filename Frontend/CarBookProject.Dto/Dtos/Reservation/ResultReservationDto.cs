﻿
namespace CarBookProject.Dto.Dtos.Reservation
{
    public class ResultReservationDto
    {
        public int ReservationId { get; set; }
        public decimal TotalCost { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public int Age { get; set; }
        public int LicenseIssuanceYear { get; set; }
        public string? AdditionalComments { get; set; }
    }
}
