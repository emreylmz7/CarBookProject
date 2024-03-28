
namespace CarBookProject.Dto.Dtos.CarFeature
{
    public class ResultCarFeatureDto
    {
        public int CarFeatureId { get; set; }
        public string? FeatureName { get; set; }
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
