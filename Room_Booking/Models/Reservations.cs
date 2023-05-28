using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Room_Booking.Models
{
    public class Reservations
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        // Foreign key
        public int CustomerId { get; set; }
        public Customer? customer { get; set; }
        public int RoomId { get; set; }
        public Rooms? rooms { get; set; }
    }
}