using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescriptionByCarId(int id);
    }
}
