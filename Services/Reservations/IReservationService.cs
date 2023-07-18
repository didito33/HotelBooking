using HotelBooking.Models.Room;

namespace HotelBooking.Services.Reservations
{
    public interface IReservationService
    {
        public bool ReserveRoom(ReserveRoomViewModel model, string userId, int roomId);
    }
}
