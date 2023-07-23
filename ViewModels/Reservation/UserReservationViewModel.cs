namespace HotelBooking.ViewModels.Reservation
{
    public class UserReservationViewModel
    {
        public string HotelName { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string GuestName { get; set; }

        public string RoomCategory { get; set; }

        public int Id { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
