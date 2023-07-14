using System.Reflection;

using HotelBooking.Data.Configurations;
using HotelBooking.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class HotelBookingDbContext : IdentityDbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Reservation> Reservations{ get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Assembly configAssembly = Assembly.GetAssembly(typeof(HotelBookingDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);


        }
    }
}