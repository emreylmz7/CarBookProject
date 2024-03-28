using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeaturesByCarId(int id);
    }
}
