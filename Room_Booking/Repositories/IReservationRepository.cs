using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservations>> Getreservations();
        Task<Reservations?> GetReservations(int id);
        Task<List<Reservations?>> PutReservations(int id, Reservations reservations);
        Task<List<Reservations>> PostReservations(Reservations reservations);
        Task<List<Reservations?>> DeleteReservations(int id);
    }

}
