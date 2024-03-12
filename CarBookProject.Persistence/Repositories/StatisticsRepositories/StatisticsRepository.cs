using CarBookProject.Application.Interfaces.StatisticsInterfaces;
using CarBookProject.Persistence.Context;

namespace CarBookProject.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAutomaticTransmissionCarCount()
        {
            return _context.Cars.Count(x => x.TransmissionType == CarBook.Domain.Enums.Transmission.Automatic);
        }

        public decimal GetAverageDailyRentPrice()
        {
            int id = _context.Pricings.Where(y=> y.Name == "Daily").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAverageHourlyRentPrice()
        {
            int id = _context.Pricings.Where(y => y.Name == "Hourly").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAverageMonthlyRentPrice()
        {
            int id = _context.Pricings.Where(y => y.Name == "Monthly").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAverageWeeklyRentPrice()
        {
            int id = _context.Pricings.Where(y => y.Name == "Weekly").Select(z => z.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public string GetBlogWithMostComments()
        {
            var blogWithMostComments = _context.Blogs!
                .OrderByDescending(b => b.Comments!.Count)
                .FirstOrDefault();

            return blogWithMostComments != null ? blogWithMostComments.Title! : "No blogs found";
        }

        public string GetBrandWithMostCars()
        {
            var brandWithMostCars = _context.Cars
                .GroupBy(c => c.Brand)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            return brandWithMostCars!.Name!;
        }

        public string GetCarBrandAndModelWithHighestDailyRentPrice()
        {
            var dailyPricingId = _context.Pricings.FirstOrDefault(y => y.Name == "Daily")?.PricingId;

            if (dailyPricingId != null)
            {
                var carIdWithHighestPrice = _context.CarPricings
                    .Where(w => w.PricingId == dailyPricingId)
                    .OrderByDescending(x => x.Amount)
                    .Select(x => x.CarId)
                    .FirstOrDefault();

                var car = _context.Cars.FirstOrDefault(c => c.CarId == carIdWithHighestPrice);
                if (car != null)
                {
                    // Null kontrolü ekleyin
                    return $"{car.Brand?.Name} {car.Model}";
                }
            }

            return "No car found with the highest daily rent price";
        }

        public string GetCarBrandAndModelWithLowestDailyRentPrice()
        {
            var dailyPricingId = _context.Pricings.FirstOrDefault(y => y.Name == "Daily")?.PricingId;

            if (dailyPricingId != null)
            {
                var carIdWithLowestPrice = _context.CarPricings
                    .Where(w => w.PricingId == dailyPricingId)
                    .OrderBy(x => x.Amount)
                    .Select(x => x.CarId)
                    .FirstOrDefault();

                var car = _context.Cars.FirstOrDefault(c => c.CarId == carIdWithLowestPrice);

                if (car != null)
                {
                    // Null kontrolü ekleyin
                    return $"{car.Brand?.Name} {car.Model}";
                }
            }
            return "No car found with the lowest daily rent price";
        }


        public int GetCarCountByKmSmallerThan1000()
        {
            return _context.Cars.Where(x => x.Km < 10000).Count();
        }

        public int GetCarCountWithPriceLessThan1000()
        {
            return _context.CarPricings.Where(x => x.Pricing!.Name == "Daily" && x.Amount <1000).Count();
        }

        public int GetElectricCarCount()
        {
            return _context.Cars.Count(c => c.Fuel == CarBook.Domain.Enums.FuelType.Electric);
        }

        public int GetGasolineOrDieselCarCount()
        {
            return _context.Cars.Count(c => c.Fuel == CarBook.Domain.Enums.FuelType.Gasoline || c.Fuel == CarBook.Domain.Enums.FuelType.Diesel);
        }

        public int GetTotalAuthorCount()
        {
            return _context.Authors.Count();
        }

        public int GetTotalBlogCount()
        {
            return _context.Blogs!.Count();
        }

        public int GetTotalBrandCount()
        {
            return _context.Cars.Select(c => c.Brand).Distinct().Count();
        }

        public int GetTotalCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetTotalLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
