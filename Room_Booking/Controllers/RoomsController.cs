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
    public class RoomsController : ControllerBase
    {
        private readonly RoomRepository _roomRepository;
        public RoomsController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Rooms>>> Getrooms()
        {
            return await _roomRepository.Getrooms();
        }



        
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRooms(int id)
        {
            var res = await _roomRepository.GetRooms(id);
            if (res == null)
            {
                return NotFound("Room not found");
            }
            return Ok(res);
        }

        [HttpPost]

        public async Task<ActionResult<List<Rooms>>> PostRooms(Rooms rom)
        {

            var res = await _roomRepository.PostRooms(rom);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Rooms>>> PutRooms(int id, Rooms rom)
        {
            var res = await _roomRepository.PutRooms(id, rom);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRooms(int id)
        {
            var res = await _roomRepository.DeleteRooms(id);
            if (res == null)
            {
                return NotFound("id not matching");
            }
            return Ok(res);
        }
    }
}
