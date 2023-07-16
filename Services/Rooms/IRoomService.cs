using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;

namespace HotelBooking.Services.Rooms
{
    public interface IRoomService
    {
        public Task AddRoom(AddRoomViewModel roomModel);
        public List<RoomCategoryViewModel> GetRoomCategories();
    }
}
