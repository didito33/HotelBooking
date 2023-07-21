using AutoMapper;

using HotelBooking.Data.Entities;
using HotelBooking.Models.Hotel;
using HotelBooking.Models.Room;
using HotelBooking.Services.Models;
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
        }
    }
}
