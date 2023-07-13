using HotelBooking.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Data.Configurations
{
    public class CategoryEntityConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private List<Category> GenerateCategories()
        {
            Category category;
            List<Category> categories = new List<Category>();
            category = new Category()
            {
                Id = 1,
                Name = "Motel"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Hostel"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Resort"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name ="Inn"
            };
            categories.Add(category);

            return categories;
        }
    }
}
