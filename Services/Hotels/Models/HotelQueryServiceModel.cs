namespace HotelBooking.Services.Hotels.Models
{
    public class HotelQueryServiceModel
    {
        public int TotalHotelsCount { get; set; }

        public IEnumerable<HotelServiceModel> Hotels = new List<HotelServiceModel>();
    }
}
