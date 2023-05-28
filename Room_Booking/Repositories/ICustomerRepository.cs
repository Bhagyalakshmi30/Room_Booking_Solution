using Microsoft.AspNetCore.Mvc;
using Room_Booking.Models;

namespace Room_Booking.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> Getcustomer();
        Task<Customer?> GetCustomer(int id);
        Task<List<Customer?>> PutCustomer(int id, Customer customer);
        Task<List<Customer>> PostCustomer(Customer customer);
        Task<List<Customer?>> DeleteCustomer(int id);
        Task<List<Customer?>> SearchCustomerByName(string name);
        int CountAllCustomers();
    }
}
