using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        List<Car> GetCarsWithBrands();
        Task CreateCarAsync(Car car);
    }
}
