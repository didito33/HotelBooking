using AutoMapper;

using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
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
        }
    }
}
