using Microsoft.AspNetCore.Mvc;
using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public interface IRoomRepository
    {
        Task<List<Rooms>> Getrooms();
        Task <Rooms?> GetRooms(int id);

        Task<List<Rooms?>> PutRooms(int id, Rooms rooms);
        Task<List<Rooms>> PostRooms(Rooms rooms);

        Task<List<Rooms?>> DeleteRooms(int id);


    }
}
