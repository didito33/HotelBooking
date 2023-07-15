﻿using HotelBooking.Data;
using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels.Models;
using HotelBooking.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Services.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingDbContext context;
        public HotelService(HotelBookingDbContext context)
        {
            this.context = context;
        }

        public async Task<HotelDetailsViewModel?> GetDetailsAsync(int id)
        {
            return await context.Hotels
                .Where(p => p.Id == id)
                .Select(p => new HotelDetailsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Description = p.Description,
                    Category = p.Category.Name,
                    City = p.City.Name,
                })
                 .FirstOrDefaultAsync();
        }

        public IEnumerable<HotelIndexServiceModel> LastThreeHotels()
            =>this.context.Hotels.OrderByDescending(h => h.Id)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name
                })
                .Take(3);
    }
}