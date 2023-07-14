using HotelBooking.Data;
using HotelBooking.Services.Models;

namespace HotelBooking.Services.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingDbContext context;
        public HotelService(HotelBookingDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<HotelIndexServiceModel> LastThreeHotels()
            =>this.context.Hotels.OrderByDescending(h => h.Id)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name
                })
                .Take(3);
        
    }
}
