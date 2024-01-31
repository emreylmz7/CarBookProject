using CarBook.Domain.Enums;

namespace CarBookProject.Application.Features.CQRS.Commands.CarCommands
{
    public class CreateCarCommand
    {
        public int BrandId { get; set; }
        public string? Model { get; set; }
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public Transmission TransmissionType { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public FuelType Fuel { get; set; }
        public string? MainImageUrl { get; set; }
    }
}
