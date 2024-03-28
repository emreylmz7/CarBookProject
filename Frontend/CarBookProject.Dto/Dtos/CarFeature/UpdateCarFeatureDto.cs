
namespace CarBookProject.Dto.Dtos.CarFeature
{
    public class UpdateCarFeatureDto
    {
        public int CarFeatureId { get; set; }
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
