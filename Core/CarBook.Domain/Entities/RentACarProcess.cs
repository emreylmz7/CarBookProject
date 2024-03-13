using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarBook.Domain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarId { get; set; }
        public int PickUpLocationId { get; set; }
        public Location? PickUpLocation { get; set; }
        public int DropOffLocationId { get; set; }
        public DropOffLocation? DropOffLocation { get; set; }

        [Column(TypeName = "Date")]
        public DateOnly PickUpDate { get; set; }

        [Column(TypeName = "Date")]
        public DateOnly DropOffDate { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly PickUpTime { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly DropOffTime { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string? PickUpDescription { get; set; }
        public string? DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
