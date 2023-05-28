using Microsoft.AspNetCore.Mvc;
using Room_Booking.Models;
using System.Security.Policy;

namespace Room_Booking.Repositories
{
    public interface IHotelRepository
    {
        Task<List<Hotels>> GetAllhotels();
        Task<Hotels?> GetHotelById(int id);

        Task<List<Hotels?>> UpdateHotel(int id, Hotels hotels);
        Task<List<Hotels>> CreateHotel(Hotels hotels);

        Task<List<Hotels?>> DeleteHotel(int id);

        public IEnumerable<Hotels> FilterHotels(string location);
        public int GetRoomCount(int RoomId, int HotelId);
        public IEnumerable<Hotels> FilterPriceRange(decimal minPrice, decimal maxPrice);
        //public List<Hotels> Search(string keyword);

    }
}
