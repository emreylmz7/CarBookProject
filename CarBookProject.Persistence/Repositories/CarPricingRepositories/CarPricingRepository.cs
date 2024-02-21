using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarPricingInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingsWithCarsAsync()
        {
            return await _context.CarPricings
                .Include(x => x.Car)
                    .ThenInclude(c => c!.Brand)
                .Include(x => x.Pricing)
                .ToListAsync();
        }
    }
}
