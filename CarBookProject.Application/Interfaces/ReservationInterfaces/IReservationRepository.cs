
using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsWithInfo();
    }
}
