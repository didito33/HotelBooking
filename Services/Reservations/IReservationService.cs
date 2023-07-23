using HotelBooking.Models.Room;
using HotelBooking.ViewModels.Reservation;
using HotelBooking.ViewModels.Room;

namespace HotelBooking.Services.Reservations
{
    public interface IReservationService
    {
        public bool ReserveRoom(ReserveRoomViewModel model, string userId, int roomId);
        public List<UserReservationViewModel> GetReservationsByUserId(string userId);
        public List<int> GetTakenRoomsIds(FilterRoomsViewModel model);
    }
}
