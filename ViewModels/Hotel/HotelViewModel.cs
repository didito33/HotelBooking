using HotelBooking.Data.Entities;

namespace HotelBooking.Models.Hotel
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
