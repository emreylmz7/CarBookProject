
namespace CarBookProject.Dto.Dtos.Statistics
{
    public class ResultStatisticsDto
    {
        public int TotalCarCount { get; set; }
        public int TotalLocationCount { get; set; }
        public int TotalAuthorCount { get; set; }
        public int TotalBlogCount { get; set; }
        public int TotalBrandCount { get; set; }
        public decimal AverageHourlyRentPrice { get; set; }
        public decimal AverageDailyRentPrice { get; set; }
        public decimal AverageWeeklyRentPrice { get; set; }
        public decimal AverageMonthlyRentPrice { get; set; }
        public int AutomaticTransmissionCarCount { get; set; }
        public string? BrandWithMostCars { get; set; }
        public int CarCountByKmSmallerThan1000 { get; set; }
        public int CarCountWithPriceLessThan1000 { get; set; }
        public int GasolineOrDieselCarCount { get; set; }
        public int ElectricCarCount { get; set; }
        public string? CarBrandAndModelWithLowestDailyRentPrice { get; set; }
        public string? BlogWithMostComments { get; set; }
        public string? CarBrandAndModelWithHighestDailyRentPrice { get; set; }


    }
}
