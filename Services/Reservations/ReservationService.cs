using AutoMapper;
using AutoMapper.QueryableExtensions;

using HotelBooking.Data;
using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
using HotelBooking.ViewModels.Reservation;
using HotelBooking.ViewModels.Room;

using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly HotelBookingDbContext context;
        private readonly IMapper mapper;

        public ReservationService(HotelBookingDbContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<UserReservationViewModel> GetReservationsByUserId(string userId)
        => this.context
            .Reservations
            .Where(r => r.UserId == userId)
            .ProjectTo<UserReservationViewModel>(this.mapper.ConfigurationProvider)
            .ToList();

        public List<int> GetTakenRoomsIds(FilterRoomsViewModel model)
        => this.context
                   .Reservations
                   .Where(r => (model.StartDate >= r.StartDate && model.StartDate < r.EndDate) || (model.EndDate >= r.StartDate && model.EndDate <= r.EndDate))
                   .Where(r => r.Room.Capacity == model.CountOfPeople)
                   .Where(r => r.Room.Hotel.City.Id == model.CityId)
                   .Select(r => r.RoomId)
                   .ToList();

        public bool ReserveRoom(ReserveRoomViewModel model, string userId, int roomId)
        {
            var isReservationDone = false;
            var roomCategory = GetRoomCategoryById(roomId);
            var hotelId = this.context
                              .Rooms
                              .FirstOrDefault(r => r.Id == roomId)
                              .HotelId;

            var freeRoom = GetFreeRoom(model.StartDate, model.EndDate, roomCategory, hotelId);

            if (freeRoom == null)
            {
                return isReservationDone;
            }

            var reservation = new Reservation()
            {
                UserId = userId,
                EndDate = model.EndDate,
                RoomId = freeRoom.Id,
                StartDate = model.StartDate,
                TotalPrice = (decimal)((model.EndDate - model.StartDate).TotalDays) * freeRoom.PricePerNight
            };

            try
            {
                this.context.Reservations.Add(reservation);
                this.context.SaveChanges();
                isReservationDone = true;
            }
            catch (Exception)
            {
                isReservationDone = false;
            }

            return isReservationDone;
        }
        private Room GetFreeRoom(DateTime startDate, DateTime endDate, string typeName, int hotelId)
        {
            var takenRoomIds = this.context
                             .Reservations
                             .Where(r => r.Room.RoomCategory.Name == typeName)
                             .Where(r => r.Room.HotelId == hotelId)
                             .Where(r => (startDate >= r.StartDate && startDate < r.EndDate) || (endDate >= r.StartDate && endDate <= r.EndDate))
                             .Select(r => r.RoomId)
                             .ToList();

            var freeRoom = this.context
                            .Rooms
                            .Where(r => !takenRoomIds.Contains(r.Id)
                            && r.RoomCategory.Name == typeName
                            && r.HotelId == hotelId)
                            .FirstOrDefault();

            return freeRoom;
        }
        private string GetRoomCategoryById(int roomId)
           => this.context
               .Rooms
               .Where(r => r.Id == roomId)
               .Select(r => r.RoomCategory.Name)
               .FirstOrDefault();
    }
}
