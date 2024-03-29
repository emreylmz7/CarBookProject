using CarBookProject.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookProject.Dto.Dtos.Reservation
{
    public class ResultReservationWithInfoDto
    {
        public int ReservationId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CarName { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public string? PickupLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public string? DropOffLocation { get; set; }
        public DateTime PreferredPickupDate { get; set; }
        public DateTime PreferredDropOffDate { get; set; }
        public int TotalRentDay { get; set; }
        public int Age { get; set; }
        public int LicenseIssuanceYear { get; set; }
        public string? AdditionalComments { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
