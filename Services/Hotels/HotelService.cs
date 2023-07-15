using HotelBooking.Data;
using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels.Models;
using HotelBooking.Services.Models;

namespace HotelBooking.Services.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingDbContext data;
        public HotelService(HotelBookingDbContext context)
        {
            this.data = context;
        }

        public IEnumerable<HotelIndexServiceModel> LastThreeHotels()
            =>this.data.Hotels.OrderByDescending(h => h.Id)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name
                })
                .Take(3);
    }
}
