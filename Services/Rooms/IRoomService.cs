using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
using HotelBooking.ViewModels.Room;
using HotelBooking.ViewModels.RoomCategory;

namespace HotelBooking.Services.Rooms
{
    public interface IRoomService
    {
        public Task AddRoomAsync(AddRoomViewModel roomModel);

        public Task<List<RoomCategoryViewModel>> GetRoomCategories();

        public Task<bool> RoomCategoryExistsByIdAsync(int id);

        public RoomViewModel? GetRoom(int roomId);
        public List<HotelRoomsViewModel> GetAllRoomsByHotel(int hotelId, FilterRoomsViewModel model);
    }
}
