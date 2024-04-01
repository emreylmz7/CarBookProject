
namespace CarBookProject.Application.Features.Mediator.Results.CarDescriptionResults
{
    public class GetCarDescriptionByIdQueryResult
    {
        public int CarDescriptionId { get; set; }
        public int CarId { get; set; }
        public string? Details { get; set; }
    }
}
