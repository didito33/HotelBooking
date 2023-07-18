using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;

namespace HotelBooking.Services.Rooms
{
    public interface IRoomService
    {
        public Task AddRoomAsync(AddRoomViewModel roomModel);

        public List<RoomCategoryViewModel> GetRoomCategories();

        public RoomViewModel? GetRoom(int roomId);
    }
}
