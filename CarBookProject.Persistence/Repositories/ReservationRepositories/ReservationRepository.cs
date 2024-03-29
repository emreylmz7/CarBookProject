using CarBook.Domain.Entities;
using CarBookProject.Application.Interfaces.ReservationInterfaces;
using CarBookProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CarBookProject.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarBookContext _context;

        public ReservationRepository(CarBookContext context)
        {
            _context = context;
        }
        public async Task<List<Reservation>> GetReservationsWithInfo()
        {
            var values = await _context.Reservations!
                .Include(x => x.Car)
                .Include(x => x.DropOffLocation)
                .Include(x => x.PickupLocation)
                .ToListAsync();
            return values;
        }
    }
}
