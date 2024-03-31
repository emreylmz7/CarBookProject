
namespace CarBookProject.Application.Features.Mediator.Results.CarPricingResults
{
    public class GetCarPricingByCarIdQueryResult
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public decimal Amount { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? PricingName { get; set; }
    }
}
