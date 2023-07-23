using AutoMapper;

using HotelBooking.Data.Entities;
using HotelBooking.Models.Hotel;
using HotelBooking.Models.Room;
using HotelBooking.Services.Models;
using HotelBooking.ViewModels.HotelCategory;
using HotelBooking.ViewModels.Reservation;
using HotelBooking.ViewModels.Room;
using HotelBooking.ViewModels.RoomCategory;

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HotelBooking
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<AddRoomViewModel, Room>();

            this.CreateMap<Room, RoomViewModel>();

            this.CreateMap<RoomCategory, RoomCategoryViewModel>();

            this.CreateMap<Hotel, HotelIndexServiceModel>();

            this.CreateMap<Hotel, HotelDetailsViewModel>()
                .ForMember(h => h.Category, cfg => cfg.MapFrom(x => x.Category.Name))
                .ForMember(h => h.City, cfg => cfg.MapFrom(x => x.City.Name))
                .ForMember(h => h.User, cfg => cfg.MapFrom(x => x.User.Email));

            this.CreateMap<Hotel, HotelViewModel>()
                .ForMember(h => h.Category, cfg => cfg.MapFrom(x => x.Category.Name));

            //this.CreateMap<Hotel, HotelCategoryViewModel>();

            this.CreateMap<Category, HotelCategoryViewModel>();

            this.CreateMap<Reservation, UserReservationViewModel>()
                .ForMember(r => r.HotelName, cfg => cfg.MapFrom(x => x.Room.Hotel.Name))
                .ForMember(r => r.StartDate, cfg => cfg.MapFrom(x => x.StartDate.ToString("d")))
                .ForMember(r => r.EndDate, cfg => cfg.MapFrom(x => x.EndDate.ToString("d")))
                .ForMember(r => r.GuestName, cfg => cfg.MapFrom(x => $"{x.User.FirstName} {x.User.LastName}"))
                .ForMember(r => r.RoomCategory, cfg => cfg.MapFrom(x => x.Room.RoomCategory.Name));

            this.CreateMap<Room, HotelRoomsViewModel>()
                .ForMember(r => r.RoomImageUrl, cfg => cfg.MapFrom(x => x.ImageUrl))
                .ForMember(r => r.RoomCategoryName, cfg => cfg.MapFrom(x => x.RoomCategory.Name));
        }
    }
}
