
namespace CarBookProject.Dto.Dtos.Car
{
    public class ResultCarWithBrandsDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string? TransmissionType { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string? Fuel { get; set; }
        public string? MainImageUrl { get; set; }
        public decimal HourlyPrice { get; set; }
    }
}
