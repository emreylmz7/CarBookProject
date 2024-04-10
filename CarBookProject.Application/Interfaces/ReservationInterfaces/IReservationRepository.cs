using CarBook.Domain.Entities;

namespace CarBookProject.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsWithInfo();
		Task<int> CreateReservationWithTotalCost(Reservation reservation);
        Task<List<Reservation>> GetReservationsByUserId(int id);
        Task<Reservation> GetReservationById(int id);
    }
}
