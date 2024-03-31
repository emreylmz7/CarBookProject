
namespace CarBookProject.Dto.Dtos.CarPricing
{
    public class ResultCarPricingDto
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal Amount { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? PricingName { get; set; }
    }
}
