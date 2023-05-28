using Microsoft.EntityFrameworkCore;

namespace Room_Booking.Models
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> user { get; set; }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Hotels> hotels { get; set; }
        public DbSet<Rooms> rooms { get; set; }
        public DbSet<Reservations> reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
