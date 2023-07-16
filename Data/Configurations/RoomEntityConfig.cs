using HotelBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Data.Configurations
{
    public class RoomEntityConfig : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasData(this.GenerateRooms());
        }

        private List<Room> GenerateRooms()
        {
           List<Room> rooms = new List<Room>();
            Room room;

            room = new Room()
            {
                Id = 1,
                Description = "Very cozy room with city view and private bathroom.",
                ImageUrl = "https://img.freepik.com/free-photo/3d-rendering-loft-luxury-living-room-with-bookshelf_105762-2104.jpg?w=996&t=st=1689254418~exp=1689255018~hmac=29c24ce3a8eb52db275aa64538a823ac83f6749f3fa0cceed9f9ebd6ef90b846",
                PricePerNight = 50,
                Capacity = 2,
                RoomCategoryId = 1,
                HotelId = 1,
            };

            rooms.Add(room);

            room = new Room()
            {
                Id = 2,
                Description = "Very stylish decorated room with a lot of charm.",
                ImageUrl = "https://img.freepik.com/free-photo/mockup-poster-frame-modern-interior-background-with-armchair-accessories-room_41470-5126.jpg?w=826&t=st=1689254644~exp=1689255244~hmac=5993c0b6b8d97d25dee1e977eaf87c3086a5a3425fb2be4ca6efd052305e319c",
                PricePerNight = 80,
                Capacity = 4,
                RoomCategoryId = 2,
                HotelId = 2,
            };

            rooms.Add(room);

            room = new Room()
            {
                Id = 3,
                Description = "Beautifull room with sea view and balcony.",
                ImageUrl = "https://img.freepik.com/free-psd/front-view-room-with-bed-modern-wooden-night-tables-mockup_176382-1962.jpg?w=826&t=st=1689254706~exp=1689255306~hmac=2f4c339bb2b6979caf45d2e93d0bf06246de3dcbc0cc84f2b14be03c30326888",
                PricePerNight = 100,
                Capacity = 2,
                RoomCategoryId = 1,
                HotelId = 3,
            };

            rooms.Add(room);

            return rooms;
        }
    }
}
