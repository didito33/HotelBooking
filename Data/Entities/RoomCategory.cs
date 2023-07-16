using System.ComponentModel.DataAnnotations;

using static HotelBooking.Common.DataConstants.RoomConstants;
namespace HotelBooking.Data.Entities
{
    public class RoomCategory
    {
        public RoomCategory()
        {
            this.Rooms = new List<Room>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(RoomTypeMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(RoomTypeDescriptionMaxLength)]
        public string Description { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
