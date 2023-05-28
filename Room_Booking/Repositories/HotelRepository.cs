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

        public IEnumerable<Hotels> FilterHotels(string location)
        {
            try
            {
                var filteredHotels = _context.hotels.AsQueryable();

                if (!string.IsNullOrEmpty(location))
                {
                    filteredHotels = filteredHotels.Where(h => h.Location.Contains(location));
                }

                return filteredHotels.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to filter hotels.", ex);
            }
        }


        public int GetRoomCount(int RoomId, int HotelId)
        {
            try
            {
                var count = (from room in _context.rooms
                             join hotel in _context.hotels on room.hotels.HotelId equals hotel.HotelId
                             where room.RoomId == RoomId && hotel.HotelId == HotelId
                             select hotel.UpdateRooms).FirstOrDefault();

                return count;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get room count by RoomId and HotelId.", ex);
            }
        }
        public IEnumerable<Hotels> FilterPriceRange(decimal minPrice, decimal maxPrice)
        {

            var priceQuery = _context.hotels.Include(x => x.rooms).AsQueryable();

            if (minPrice > 0)
            {
                priceQuery = priceQuery.Where(r => r.PricePerDay >= minPrice);
            }

            if (maxPrice > 0)
            {
                priceQuery = priceQuery.Where(r => r.PricePerDay <= maxPrice);
            }

            return priceQuery.ToList();

        }


    }
}
