using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotels>> CreateHotel(Hotels hot)
        {
            _context.hotels.Add(hot);
            await _context.SaveChangesAsync();
            return await _context.hotels.ToListAsync();
        }

        public async Task<List<Hotels?>> DeleteHotel(int id)
        {
            var res = await _context.hotels.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return await _context.hotels.ToListAsync();
        }

        public async Task<List<Hotels>> GetAllhotels()
        {
            var res = await _context.hotels.ToListAsync();
            return res;
        }

        public async Task<Hotels?> GetHotelById(int id)
        {
            var res = await _context.hotels.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            return res;
        }

        public async Task<List<Hotels?>> UpdateHotel(int id, Hotels hot)
        {
            var res = await _context.hotels.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            res.HotelName = hot.HotelName;
            res.rooms = hot.rooms;
            res.CreationYear = hot.CreationYear;
            res.UpdateRooms=hot.UpdateRooms;
            res.Location= hot.Location;
            res.PricePerDay= hot.PricePerDay;
            await _context.SaveChangesAsync();
            return await _context.hotels.ToListAsync();

        }
    }
}
