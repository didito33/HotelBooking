namespace HotelBooking.Models.Room
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string RoomCategory { get; set; }

        public string ImageURL { get; set; }

        public string Description { get; set; }

        public string HotelName { get; set; }

        public int HotelId { get; set; }

        public decimal PriceForOneNight { get; set; }
    }
}
