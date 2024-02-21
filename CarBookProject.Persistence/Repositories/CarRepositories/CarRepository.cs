using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.CarInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic; // Don't forget to include this namespace

namespace CarBookProject.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsWithBrands()
        {
            // Include both Brand and CarPricing entities
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
