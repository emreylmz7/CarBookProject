
namespace CarBookProject.Application.Features.Mediator.Results.CarFeatureResults
{
    public class GetCarFeatureByCarIdQueryResult
    {
        public int CarFeatureId { get; set; }
        public string? FeatureName { get; set; }
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
