using HotelBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Data.Configurations
{
    public class RoomCategoryEntityConfig : IEntityTypeConfiguration<RoomCategory>
    {
        public void Configure(EntityTypeBuilder<RoomCategory> builder)
        {
            builder.HasData(this.GenerateRoomCategories());
        }

        private List<RoomCategory> GenerateRoomCategories()
        {
            List<RoomCategory> roomCategories = new List<RoomCategory>();
            RoomCategory roomCategory;
            roomCategory = new RoomCategory()
            {
                Id = 1,
                Name = "Double",
                Description = "A room for 2 people"
            };
            roomCategories.Add(roomCategory);

            roomCategory = new RoomCategory() { Id = 2, Name = "Apartment", Description = "A room for more than 2 people" };
            roomCategories.Add(roomCategory);

            roomCategory = new RoomCategory()
            {
                Id = 3,
                Name = "Studio",
                Description = "A room suitable for more than 3 people."
            };
            roomCategories.Add(roomCategory);

            return roomCategories;

        }
    }
}
