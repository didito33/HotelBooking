

using System.ComponentModel;

namespace HotelBooking.Services.Hotels.Models
{
    public class HotelServiceModel
    {
        public int Id { get; set; }

        
        public string Name { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }
        [DisplayName("Is Full")]
        public bool IsFull { get; set; }
    }
}
