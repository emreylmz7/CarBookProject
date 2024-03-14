
namespace CarBookProject.Dto.Dtos.RentACar
{
    public class FilterRentACarDto
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public decimal HourlyPrice { get; set; }
        public int Km { get; set; }
        public string? TransmissionType { get; set; }
        public string? Fuel { get; set; }
    }
}
