using HotelBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Data.Configurations
{
    public class CityEntityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(this.GenerateCities());
        }

        private List<City> GenerateCities()
        {
            List<City> cities = new List<City>();

            City city;

            city = new City()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1,
            };

            cities.Add(city);

            city = new City()
            {
                Id = 2,
                Name = "Miami",
                CountryId = 2,
            };

            cities.Add(city);

            city = new City()
            {
                Id = 3,
                Name = "Positano",
                CountryId = 3,
            };

            cities.Add(city);

            return cities;  
        }
    }
}