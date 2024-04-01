using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync(); // Arabayı veritabanına kaydet

            // Araba kaydedildikten sonra, CarId'sini al
            var carId = car.CarId;

            var carPricings = new List<CarPricing>
            {
                new CarPricing { CarId = carId, PricingId = 2, Amount = 100 },
                new CarPricing { CarId = carId, PricingId = 3, Amount = 300 },
                new CarPricing { CarId = carId, PricingId = 4, Amount = 500 },
                new CarPricing { CarId = carId, PricingId = 5, Amount = 800 }
            };

			var carFeatures = new List<CarFeature>
			{
				new CarFeature { CarId = carId, FeatureId = 1, Available = true },
				new CarFeature { CarId = carId, FeatureId = 6, Available = true },
				new CarFeature { CarId = carId, FeatureId = 2, Available = true },
			};

			_context.CarPricings.AddRange(carPricings);
			_context.CarFeatures.AddRange(carFeatures);

            await _context.SaveChangesAsync();
        }


        public List<Car> GetCarsWithBrands()
        {
            var carsWithBrandsAndPricing = _context.Cars
                .Include(x => x.Brand)
                .Include(x => x.CarPricing)
                .ToList();

            // Now you can access Amount property under CarPricing
            foreach (var car in carsWithBrandsAndPricing)
            {
                foreach (var pricing in car.CarPricing!)
                {
                    var amount = pricing.Amount;
                }
            }

            return carsWithBrandsAndPricing;
        }
    }
}
