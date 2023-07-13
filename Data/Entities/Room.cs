using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace HotelBooking.Data.Entities
{
    public class Room
    {
        public Room()
        {
            Reservations = new List<Reservation>();
        }
        public int Id { get; set; }

        [Required]
        [Comment("Description of the Room")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; }
        public List<Reservation> Reservations { get; set; }

    }
}
