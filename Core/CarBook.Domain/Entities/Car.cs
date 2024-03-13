using CarBook.Domain.Enums;

namespace CarBook.Domain.Entities
{
    public class Car
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public Transmission TransmissionType { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public string? MainImageUrl { get; set; }
        public List<CarFeature>? CarFeatures { get; set; }
        public List<CarDescription>? CarDescriptions { get; set; }
        public List<CarPricing>? CarPricing { get; set; }
        public List<RentACar>? RentACars { get; set; }
    }
}
