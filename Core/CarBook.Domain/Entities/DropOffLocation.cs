
namespace CarBook.Domain.Entities
{
    public class DropOffLocation
    {
        public int DropOffLocationId { get; set; }
        public string? Name { get; set; }
        public List<RentACarProcess>? RentACarProcesses { get; set; }
    }
}
