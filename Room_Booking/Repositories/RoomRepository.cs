using Microsoft.EntityFrameworkCore;
using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;
        public RoomRepository(HotelDbContext context)
        {
            _context = context;
                
        }
        public async Task<List<Rooms>> DeleteRooms(int id)
        {
            var res = await _context.rooms.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return await _context.rooms.ToListAsync();
        }

        public async Task<List<Rooms>> Getrooms()
        {
            var res = await _context.rooms.ToListAsync();
            return res;
        }

        public async Task<Rooms?> GetRooms(int id)
        {
            var res = await _context.rooms.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            return res;
        }

        public async Task<List<Rooms>> PostRooms(Rooms rooms)
        {
            _context.rooms.Add(rooms);
            await _context.SaveChangesAsync();
            return await _context.rooms.ToListAsync();
        }

        public async Task<List<Rooms?>> PutRooms(int id, Rooms rooms)
        {
            var res = await _context.rooms.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            res.RoomNumber = rooms.RoomNumber;
            res.RoomId= rooms.RoomId;
            res.Price= rooms.Price;
            res.reservations = rooms.reservations;
            res.HotelId= rooms.HotelId;
            res.RoomType= rooms.RoomType;
            res.IsAvailable= rooms.IsAvailable;
            res.hotels= rooms.hotels;
            await _context.SaveChangesAsync();
            return await _context.rooms.ToListAsync();
        }
    }
}
