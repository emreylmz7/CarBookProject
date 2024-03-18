
using System.ComponentModel.DataAnnotations;

namespace CarBookProject.Dto.Dtos.RentACar
{
    public class SearchRentACarDto
    {
        [Required(ErrorMessage = "Pick-up location is required.")]
        public string? LocationId { get; set; }

        [Required(ErrorMessage = "Drop-off location is required.")]
        public string? DropOffLocationId { get; set; }

        [Required(ErrorMessage = "Pick-up date is required.")]
        [DataType(DataType.Date)]
        public DateTime BookPickDate { get; set; }

        [Required(ErrorMessage = "Drop-off date is required.")]
        [DataType(DataType.Date)]
        public DateTime BookOffDate { get; set; }

        [Required(ErrorMessage = "Pick-up time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimePick { get; set; }

        [Required(ErrorMessage = "Drop-off time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan TimeDrop { get; set; }
    }
}
