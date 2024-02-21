using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarPricingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPricingsWithCarsAsync();
    }

}
