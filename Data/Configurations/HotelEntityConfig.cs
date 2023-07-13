using HotelBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Data.Configurations
{
    public class HotelEntityConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(this.GenerateHotels());
        }

        private List<Hotel> GenerateHotels()
        {
            List<Hotel> hotels = new List<Hotel>();

            Hotel hotel;

            hotel = new Hotel()
            {
                Id = 1,
                Name = "Happy Days",
                Description = "This is our happy space for your happy days!!!",
                ImageUrl = "https://img.freepik.com/free-photo/colonial-style-house-night-scene_1150-17925.jpg?w=996&t=st=1689255070~exp=1689255670~hmac=dee9381ab587fcbf662cf91576a7a05cca10b06570fa802a29735846d12ffd4b",
                CategoryId = 1,
                CityId = 1
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 2,
                Name = "Comfort Deluxe Hotel",
                Description = "This is the comfort deluxe hotel in Miami.",
                ImageUrl = "https://img.freepik.com/premium-photo/luxury-pool-villa-spectacular-contemporary-design-digital-art-real-estate-home-house-property-ge_1258-150753.jpg?w=996",
                CategoryId = 2,
                CityId = 2
            };

            hotels.Add(hotel);


            hotel = new Hotel()
            {
                Id = 3,
                Name = "Sea And Sun",
                Description = "This is our sunny hotel, located on the beach.",
                ImageUrl = "https://img.freepik.com/free-photo/popular-resort-amara-dolce-vita-luxury-hotel-with-pools-water-parks-recreational-area-along-sea-coast-turkey-sunset-tekirova-kemer_146671-18752.jpg?w=996&t=st=1689255117~exp=1689255717~hmac=960e554d1d140cf76b8b039791cdd1d9d86e547089cbbd969898fe46f84e0930",
                CategoryId = 3,
                CityId = 3
            };

            hotels.Add(hotel);

            return hotels;
        }
    }
}
