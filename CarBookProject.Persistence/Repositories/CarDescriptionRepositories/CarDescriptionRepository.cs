using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarDescriptionInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<CarDescription> GetCarDescriptionByCarId(int id)
        {
            var value = await _context.CarDescriptions
                .Where(x => x.CarId == id).FirstOrDefaultAsync();
            return value!;
        }
    }
}
