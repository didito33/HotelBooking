using HotelBooking.Models.Room;
using HotelBooking.Data.Entities;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using HotelBooking.ViewModels.RoomCategory;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelBooking.ViewModels.Room;
using HotelBooking.Services.Reservations;

namespace HotelBooking.Services.Rooms
{
    public class RoomService : IRoomService
    {
        private readonly HotelBookingDbContext context;
        private readonly IMapper mapper;
        private readonly IReservationService reservationService;
        public RoomService(HotelBookingDbContext dbcontext, IMapper mapper, IReservationService reservationService)
        {
            this.context = dbcontext;
            this.mapper = mapper;
            this.reservationService = reservationService;
        }
        public async Task<List<RoomCategoryViewModel>> GetRoomCategories()
            => await this.context
                   .RoomCategories
                   .ProjectTo<RoomCategoryViewModel>(this.mapper.ConfigurationProvider)
                   .ToListAsync();
        /*public async Task<List<RoomCategoryViewModel>> GetRoomCategories()
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
        }*/

        public async Task<bool> RoomCategoryExistsByIdAsync(int id)
        {
            bool result = await this.context.RoomCategories
                .AnyAsync(p => p.Id == id);

            return result;
        }
        public RoomViewModel? GetRoom(int roomId)
            => this.context
                   .Rooms
                   .Where(r => r.Id == roomId)
                   .ProjectTo<RoomViewModel>(this.mapper.ConfigurationProvider)
                   .FirstOrDefault();
        /*public RoomViewModel? GetRoom(int roomId)
          => this.context
            .Rooms
            .Where(r=>r.Id == roomId)
            .Select(r=> new RoomViewModel()
            {
                Id = r.Id,
                Description = r.Description,
                HotelId=r.HotelId,
                PricePerNight = r.PricePerNight,
                HotelName = r.Hotel.Name,
                ImageURL = r.ImageUrl,
                RoomCategory = r.RoomCategory.Name
                
            })
            .FirstOrDefault();*/

        public async Task AddRoomAsync(AddRoomViewModel roomModel)
        {
            Room room = mapper.Map<Room>(roomModel);
           /* Room room = new Room()
            {
                //Id = roomModel.Id, //Breaks the code - Identity 
                Description = roomModel.Description,
                ImageUrl = roomModel.ImageURL,
                Capacity = roomModel.Capacity,
                HotelId = roomModel.HotelId,
                PricePerNight = roomModel.PricePerNight,
                RoomCategoryId = roomModel.RoomCategoryId
                //RoomCategory = context.RoomCategories.Where(x => x.Id == roomModel.RoomCategoryId).First()
            };*/

            await this.context.Rooms.AddAsync(room);
            await this.context.SaveChangesAsync();
        }

        public List<HotelRoomsViewModel> GetAllRoomsByHotel(int hotelId, FilterRoomsViewModel model)
        {
            var rooms = new List<HotelRoomsViewModel>();

            if (model.CountOfPeople == 0)
            {
                rooms = this.context
                            .Rooms
                            .Where(r => r.HotelId == hotelId)
                            .ProjectTo<HotelRoomsViewModel>(this.mapper.ConfigurationProvider)
                            .ToList()
                            .DistinctBy(r => r.RoomCategoryName)
                            .ToList();
            }
            else
            {
                var takenRoomsIds = this.reservationService.GetTakenRoomsIds(model);

                rooms = this.context
                            .Rooms
                            .Where(r => r.HotelId == hotelId)
                            .Where(r => r.Capacity == model.CountOfPeople)
                            .Where(r => !takenRoomsIds.Contains(r.Id))
                            .ProjectTo<HotelRoomsViewModel>(this.mapper.ConfigurationProvider)
                            .ToList()
                            .DistinctBy(r => r.RoomCategoryName)
                            .ToList();
            }

            return rooms;
        }
    }
}
