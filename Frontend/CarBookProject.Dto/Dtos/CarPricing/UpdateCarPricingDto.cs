
namespace CarBookProject.Dto.Dtos.CarPricing
{
    public class UpdateCarPricingDto
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
