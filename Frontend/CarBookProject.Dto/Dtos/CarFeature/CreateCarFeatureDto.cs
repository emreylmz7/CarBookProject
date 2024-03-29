
namespace CarBookProject.Dto.Dtos.CarFeature
{
    public class CreateCarFeatureDto
    {
        public int FeatureId { get; set; }
        public int CarId { get; set; }
        public bool Available { get; set; }
    }
}
