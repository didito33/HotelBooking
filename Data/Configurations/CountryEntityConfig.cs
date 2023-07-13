using HotelBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace HotelBooking.Data.Configurations
{
    public class CountryEntityConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(this.GenerateCountries());
        }

        private List<Country> GenerateCountries()
        {
            List<Country> countries = new List<Country>();
           
            Country country;

            country = new Country()
            {
                Id = 1,
                Name = "Bulgaria"
            };
        
            countries.Add(country);

            country = new Country()
            {
                Id = 2,
                Name = "United States of America"
            };

            countries.Add(country);

            country = new Country()
            {
                Id = 3,
                Name = "Italy"
            };

            countries.Add(country);

            return countries;
        }
    }
}
