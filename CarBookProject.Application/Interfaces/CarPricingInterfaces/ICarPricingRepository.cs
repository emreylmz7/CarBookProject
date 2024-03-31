using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingsWithCarsAsync();
        Task<List<CarPricing>> GetCarPricingByCarIdAsync(int id);
        Task<CarPricing> GetCarPricingByIdAsync(int id);
        Task<List<CarPricing>> GetCarPricingsAsync();
    }

}
