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
    public class ReservationsController : ControllerBase
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationsController(ReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservations>>> Getreservations()
        {
            return await _reservationRepository.Getreservations();
        }



        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservations(int id)
        {
            var res = await _reservationRepository.GetReservations( id);
            if (res == null)
            {
                return NotFound("Student not found");
            }
            return Ok(res);
        }

        [HttpPost]

        public async Task<ActionResult<List<Reservations>>> PostReservations(Reservations reservations)
        {

            var res = await _reservationRepository.PostReservations(reservations);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Reservations>>> PutReservations(int id, Reservations reservations)
        {
            var res = await _reservationRepository.PutReservations(id, reservations);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservations(int id)
        {
            var res = await _reservationRepository.DeleteReservations(id);
            if (res == null)
            {
                return NotFound("id not matching");
            }
            return Ok(res);
        }






    }
}
