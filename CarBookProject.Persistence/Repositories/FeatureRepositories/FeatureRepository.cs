using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.FeatureInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.FeatureRepositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly CarBookContext _context;

        public FeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Feature>> GetFeaturesNotInThisCar(int id)
        {
            var featuresInCarIds = await _context.CarFeatures
                .Where(x => x.CarId == id)
                .Select(x => x.FeatureId)
                .ToListAsync();

            var featuresNotInCar = await _context.Features
                .Where(feature => !featuresInCarIds.Contains(feature.FeatureId))
                .ToListAsync();

            return featuresNotInCar;
        }
    }
}
