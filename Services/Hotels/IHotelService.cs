using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels.Models;
using HotelBooking.Services.Models;

namespace HotelBooking.Services.Hotels
{
    public interface IHotelService
    {
        IEnumerable<HotelIndexServiceModel> LastThreeHotels();
        //IEnumerable<>
    }
}
