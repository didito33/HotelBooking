using HotelBooking.Models.Room;
using HotelBooking.Data.Entities;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly HotelBookingDbContext context;
        public RoomService(HotelBookingDbContext dbcontext)
        {
            context = dbcontext;
        }
        public async Task AddRoom(AddRoomViewModel roomModel)
        {

            Room room = new Room()
            {
                Id = roomModel.Id,
                Capacity = roomModel.Capacity,
                Description = roomModel.Description,
                HotelId = roomModel.HotelId,
                ImageUrl = roomModel.ImageURL,
                PricePerNight = roomModel.Price,
                RoomCategoryId = roomModel.RoomCategoryId
            };
            this.context.Rooms.Add(room);
            await context.SaveChangesAsync();
        }

        public List<RoomCategoryViewModel> GetRoomCategories()
        {
            return this.context.RoomCategories.Select(c => new RoomCategoryViewModel()
            {
                Name = c.Name,
                Id = c.Id,
                Description =c.Description,
            }).ToList();
        }

        public RoomViewModel? GetRoom(int roomId)
          => this.context
            .Rooms
            .Where(r=>r.Id == roomId)
            .Select(r=> new RoomViewModel()
            {
                Description = r.Description,
                HotelId=r.HotelId,
                PriceForOneNight = r.PricePerNight,
                HotelName = r.Hotel.Name,
                Id = r.Id,
                ImageURL = r.ImageUrl,
                RoomCategory = r.RoomCategory.Name
            })
            .FirstOrDefault();

        public async Task AddRoomAsync(AddRoomViewModel roomModel)
        {
            Room room = new Room()
            {
                Id = roomModel.Id,
                Description = roomModel.Description,
                ImageUrl = roomModel.ImageURL,
                Capacity = roomModel.Capacity,
                HotelId = roomModel.HotelId,
                PricePerNight = roomModel.Price,
                RoomCategoryId = roomModel.RoomCategoryId
            };

            await this.context.Rooms.AddAsync(room);
            await this.context.SaveChangesAsync();
        }
    }
}
