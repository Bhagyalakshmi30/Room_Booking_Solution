using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public Task<List<Reservations?>> DeleteReservations(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservations>> Getreservations()
        {
            throw new NotImplementedException();
        }

        public Task<Reservations?> GetReservations(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservations>> PostReservations(Reservations reservations)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reservations?>> PutReservations(int id, Reservations reservations)
        {
            throw new NotImplementedException();
        }
    }
}
