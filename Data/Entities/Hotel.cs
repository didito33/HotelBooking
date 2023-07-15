using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static HotelBooking.Data.DataConstants.HotelConstants;
#nullable disable
namespace HotelBooking.Data.Entities
{
    public class Hotel
    {
        public Hotel()
        {
            this.Rooms = new List<Room>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(HotelNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        public List<Room> Rooms { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
    }
}
