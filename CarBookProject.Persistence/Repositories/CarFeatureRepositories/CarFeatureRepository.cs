using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarFeatureInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;

        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<List<CarFeature>> GetCarFeaturesByCarId(int id)
        {
            var values = await _context.CarFeatures!
                .Include(x => x.Feature)
                .Where(x => x.CarId == id).ToListAsync();
            return values;
        }
    }
}
