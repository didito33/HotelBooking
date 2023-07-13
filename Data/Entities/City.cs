using System.ComponentModel.DataAnnotations.Schema;
#nullable disable
namespace HotelBooking.Data.Entities
{
    public class City
    {
        public City()
        {
            Hotels = new List<Hotel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
