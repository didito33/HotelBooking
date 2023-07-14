using HotelBooking.Services.Models;

namespace HotelBooking.Services.Hotels
{
    public interface IHotelService
    {
        IEnumerable<HotelIndexServiceModel> LastThreeHotels();
    }
}
