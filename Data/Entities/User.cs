using Microsoft.AspNetCore.Identity;
#nullable disable
namespace HotelBooking.Data.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Reservations = new List<Reservation>();
            this.Hotels = new List<Hotel>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
