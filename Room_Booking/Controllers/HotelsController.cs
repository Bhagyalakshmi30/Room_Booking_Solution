using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room_Booking.Models;
using Room_Booking.Repositories;

namespace Room_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly HotelRepository _hotelRepository;

        public HotelsController(HotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotels>>> GetAllhotels()
        {
            return await _hotelRepository.GetAllhotels();
        }



        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotels>> GetHotelById(int id)
        {
            var res = await _hotelRepository.GetHotelById(id);
            if (res == null)
            {
                return NotFound("Student not found");
            }
            return Ok(res);
        }

        [HttpPost]

        public async Task<ActionResult<List<Hotels>>> CreateHotel(Hotels hotels)
        {

            var res = await _hotelRepository.CreateHotel(hotels);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hotels>>> UpdateHotel(int id, Hotels hotels)
        {
            var res = await _hotelRepository.UpdateHotel(id, hotels);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var res = await _hotelRepository.DeleteHotel(id);
            if (res == null)
            {
                return NotFound("id not matching");
            }
            return Ok(res);
        }



























        //// GET: api/Hotels
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Hotels>>> GetAllhotels()
        //{
        //    try
        //    {
        //        var hotels = await _hotelRepository.GetAllhotels();
        //        return Ok(hotels);
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        //// GET: api/Hotels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Hotels>> GetHotelById(int id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {
        //        var hotels = await _hotelRepository.GetHotelById(id);
        //        return Ok(hotels);
        //    }

        //    catch
        //    {
        //        return NotFound();
        //    }


        //}

        //// PUT: api/Hotels/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateHotel(int id, Hotels hotels)
        //{
        //    if (id != hotels.HotelId)
        //    {
        //        throw new ArgumentException(nameof(id));
        //    }



        //    try
        //    {
        //         await _hotelRepository.UpdateHotel(id, hotels);
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //          return NotFound();

        //    }

        //    return NoContent();
        //}

        //// POST: api/Hotels
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<IActionResult> CreateHotel(Hotels hotels)
        //{
        //    if (hotels == null)
        //    {
        //        return NotFound();
        //    }
        //    try
        //    {
        //        _hotelRepository.CreateHotel(hotels);
        //        return Ok("Value Added");
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e);
        //    }
        //}

        //// DELETE: api/Hotels/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteHotel(int id)
        //{
        //    if (_hotelRepository.GetHotelById(id) == null)
        //    {
        //        return NotFound();
        //    }
        //    var hotels = await _hotelRepository.GetHotelById(id);
        //    if (hotels == null)
        //    {
        //        return NotFound();
        //    }

        //    _hotelRepository.DeleteHotel(id);


        //    return NoContent();
    }




}

