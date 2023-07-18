using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HotelBooking.Models.Room
{
    public class ReserveRoomViewModel
    {
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
