using HotelBooking.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Models.Hotel
{
    public class HotelDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string User { get; set; }

        public string City { get; set; }
    }
}
