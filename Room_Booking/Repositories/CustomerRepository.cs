using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HotelDbContext _context;
        public CustomerRepository(HotelDbContext context)
        {
            _context = context;

        }

        public  int CountAllCustomers()
        {
            var res =  _context.customer.Count();
            return res;
            
            //FromSql("SELECT COUNT(*) as count_cust FROM Customer;");
        }

        public async Task<List<Customer?>> DeleteCustomer(int id)
        {
            var res = await _context.customer.FindAsync(id);
            if (res == null)
            {
                return null;
            }
            _context.Remove(res);
            await _context.SaveChangesAsync();
            return await _context.customer.ToListAsync();

        }

        public async Task<List<Customer>> Getcustomer()
        {
           var res= await _context.customer.ToListAsync();
            return res;
        }

        public async  Task<Customer?> GetCustomer(int id)
        {
            var res=await _context.customer.FindAsync(id);
            if(res==null)
            {
                return null;
            }
            return res;
        }

        public async Task<List<Customer>> PostCustomer(Customer customer)
        {
           _context.customer.Add(customer);
            await _context.SaveChangesAsync();
            return await _context.customer.ToListAsync();
        }

        public async  Task<List<Customer?>> PutCustomer(int id, Customer cust)
        {
             var res = await _context.customer.FindAsync(id);
            if(res==null) 
            {
                return null;
            }
            res.PhoneNumber = cust.PhoneNumber;
            res.LastName = cust.LastName;
            res.FirstName = cust.FirstName;
            res.Address= cust.Address;
            res.City = cust.City;
            res.Email = cust.Email; 
            res.City= cust.City;
            await _context.SaveChangesAsync();
            return await _context.customer.ToListAsync();
        }

        
        

       
    }
}
