using HotelBooking.Models.Room;
using HotelBooking.Data.Entities;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using HotelBooking.ViewModels.RoomCategory;

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

        public async Task<List<RoomCategoryViewModel>> GetRoomCategories()
        {
            List<RoomCategoryViewModel> categories = 
                await this.context.RoomCategories
                .AsNoTracking()
                .Select(c => new RoomCategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return categories;
        }

        public async Task<bool> RoomCategoryExistsByIdAsync(int id)
        {
            bool result = await this.context.RoomCategories
                .AnyAsync(p => p.Id == id);

            return result;
        }

        public RoomViewModel? GetRoom(int roomId)
          => this.context
            .Rooms
            .Where(r=>r.Id == roomId)
            .Select(r=> new RoomViewModel()
            {
                Id = r.Id,
                Description = r.Description,
                HotelId=r.HotelId,
                PriceForOneNight = r.PricePerNight,
                HotelName = r.Hotel.Name,
                ImageURL = r.ImageUrl,
                RoomCategory = r.RoomCategory.Name
            })
            .FirstOrDefault();

        public async Task AddRoomAsync(AddRoomViewModel roomModel)
        {
            Room room = new Room()
            {
                //Id = roomModel.Id, //Breaks the code - Identity 
                Description = roomModel.Description,
                ImageUrl = roomModel.ImageURL,
                Capacity = roomModel.Capacity,
                HotelId = roomModel.HotelId,
                PricePerNight = roomModel.Price,
                RoomCategoryId = roomModel.RoomCategoryId
                //RoomCategory = context.RoomCategories.Where(x => x.Id == roomModel.RoomCategoryId).First()
            };

            await this.context.Rooms.AddAsync(room);
            await this.context.SaveChangesAsync();
        }
    }
}
