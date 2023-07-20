namespace HotelBooking.Models.Room
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string RoomCategory { get; set; } = null!;

        public string ImageURL { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string HotelName { get; set; } = null!;

        public int HotelId { get; set; }

        public decimal PricePerNight { get; set; }
    }
}
