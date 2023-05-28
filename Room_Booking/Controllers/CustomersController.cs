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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Getcustomer()
        {
            return await _customerRepository.Getcustomer();
        }



        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var res= await _customerRepository.GetCustomer(id);
            if(res==null)
            {
                return NotFound("Student not found");
            }
            return Ok(res);
        }

        [HttpPost]

        public async Task<ActionResult <List<Customer>>> PostCustomer( Customer cust)
        {
            
            var res = await _customerRepository.PostCustomer(cust);
            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> PutCustomer(int id, Customer cust)
        {
            var res = await _customerRepository.PutCustomer(id,cust);
            if(res==null)
            {
                return NotFound();
            }
            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var res=await _customerRepository.DeleteCustomer(id);
            if(res==null)
            {
                return NotFound("id not matching");
            }
            return Ok(res);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Customer>>> SearchCustomerByName(string name)
        {
            var res = await _customerRepository.SearchCustomerByName(name);
            if (res == null)
            {
                return NotFound("id not matching");
            }
            return Ok(res);

        }

        [HttpGet]
        public  int CountAllCustomers()
        {
            int res = _customerRepository.CountAllCustomers();
            if (res == null)
            {
                return 0;
            }
            return res;
        }







































        //// GET: api/Customers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> Getcustomer()
        //{
        //  if (_context.customer == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.customer.ToListAsync();
        //}

        //// GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //  if (_context.customer == null)
        //  {
        //      return NotFound();
        //  }
        //    var customer = await _context.customer.FindAsync(id);

        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return customer;
        //}

        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer customer)
        //{
        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        //{
        //  if (_context.customer == null)
        //  {
        //      return Problem("Entity set 'HotelDbContext.customer'  is null.");
        //  }
        //    _context.customer.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        //}

        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    if (_context.customer == null)
        //    {
        //        return NotFound();
        //    }
        //    var customer = await _context.customer.FindAsync(id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.customer.Remove(customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CustomerExists(int id)
        //{
        //    return (_context.customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        //}
    }
}
