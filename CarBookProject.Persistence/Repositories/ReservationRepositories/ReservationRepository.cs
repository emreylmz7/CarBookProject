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

		public async Task<int> CreateReservationWithTotalCost(Reservation reservation)
		{
			var carPriceForDay = _context.CarPricings.Where(x=> x.CarId == reservation.CarId && x.PricingId == 3).FirstOrDefault();
			int rentalDuration = (reservation.PreferredDropOffDate - reservation.PreferredPickupDate).Days;
            var totalPrice = carPriceForDay!.Amount * rentalDuration;
            reservation.TotalCost = totalPrice;
            _context.Reservations.Add(reservation);
			await _context.SaveChangesAsync();

            return reservation.ReservationId;

        }

        public async Task<List<Reservation>> GetReservationsByUserId(int id)
        {
            var values = await _context.Reservations!
                .Where(x => x.AppUserId == id)
                .Include(x => x.Car)
                .Include(x => x.DropOffLocation)
                .Include(x => x.PickupLocation)
                .ToListAsync();
            return values!;
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
