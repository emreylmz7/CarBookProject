namespace CarBookProject.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetTotalCarCount();
        int GetTotalLocationCount();
        int GetTotalAuthorCount();
        int GetTotalBlogCount();
        int GetTotalBrandCount();
        decimal GetAverageHourlyRentPrice();
        decimal GetAverageDailyRentPrice();
        decimal GetAverageWeeklyRentPrice();
        decimal GetAverageMonthlyRentPrice();
        int GetAutomaticTransmissionCarCount();
        string GetBrandWithMostCars();
        string GetBlogWithMostComments();
        int GetCarCountByKmSmallerThan1000();
        int GetCarCountWithPriceLessThan1000();
        int GetGasolineOrDieselCarCount();
        int GetElectricCarCount();
        string GetCarBrandAndModelWithHighestDailyRentPrice();
        string GetCarBrandAndModelWithLowestDailyRentPrice();
    }
}
