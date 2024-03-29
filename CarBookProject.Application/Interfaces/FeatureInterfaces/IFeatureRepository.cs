using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.FeatureInterfaces
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetFeaturesNotInThisCar(int id);
    }
}
