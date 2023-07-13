using System.ComponentModel.DataAnnotations;

using static HotelBooking.Data.DataConstants.CategoryConstants;
#nullable disable
namespace HotelBooking.Data.Entities
{
    public class Category
    {
        public Category()
        {
            this.Hotels = new List<Hotel>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public List<Hotel> Hotels { get; init; }
    }
}
