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
        //public List<Hotels> Search(string keyword);

    }
}
