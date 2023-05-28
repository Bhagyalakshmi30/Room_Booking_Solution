using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Room_Booking.Models
{
    public class Rooms
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoomId { get; set; }

        public string? RoomType { get; set; }

        public int RoomNumber { get; set; }

        public int Price { get; set; }
        public bool IsAvailable { get; set; }

        //Foreign key
        public int HotelId { get; set; }
        public Hotels? hotels { get; set; }

        //Navigation
        public ICollection<Reservations>? reservations { get; set; }
    }
}
