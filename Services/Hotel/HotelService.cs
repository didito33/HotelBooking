using AutoMapper;
using AutoMapper.QueryableExtensions;

using HotelBooking.Data;
using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels.Models;
using HotelBooking.ViewModels.Hotel;
using HotelBooking.Services.Models;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data.Entities;
using HotelBooking.ViewModels.RoomCategory;
using HotelBooking.ViewModels.HotelCategory;

namespace HotelBooking.Services.Hotels
{
    public class HotelService : IHotelService
    {
        private readonly HotelBookingDbContext context;
        private readonly IMapper mapper;
        public HotelService(HotelBookingDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync()
            => await this.context.Hotels.ProjectTo<HotelViewModel>(this.mapper.ConfigurationProvider)
            .ToListAsync();
        public async Task<HotelDetailsViewModel?> GetDetailsAsync(int id)
        => await this.context.Hotels
            .Where(p => p.Id == id)
            .ProjectTo<HotelDetailsViewModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        public async Task<HotelEditViewModel> GetHotelForEditByIdAsync(string hotelId)
        {
            Hotel hotel = await this.context
                .Hotels
                .Include(h => h.Category)
                .Include(h=>h.City)
                .FirstAsync(h => h.Id.ToString() == hotelId);

            return new HotelEditViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                City = hotel.City.Name,
                Description = hotel.Description,
                ImageUrl = hotel.ImageUrl,
                CategoryId = hotel.CategoryId,
            };
        }

        public async Task EditHotelByIdAsync(string hotelId, HotelEditViewModel formModel)
        {
            Hotel hotel = await this.context
                .Hotels
                .Include(h=>h.City)
                .FirstAsync(h => h.Id.ToString() == hotelId);

            //hotel.Id = formModel.Id;
            hotel.Name = formModel.Name;
            hotel.City.Name = formModel.City;
            hotel.Description = formModel.Description;
            hotel.ImageUrl = formModel.ImageUrl;
            hotel.CategoryId = formModel.CategoryId;

            await this.context.SaveChangesAsync();
        }
        public IEnumerable<HotelIndexServiceModel> LastThreeHotels() =>
            this.context.Hotels.OrderByDescending(h => h.Id)
            .ProjectTo<HotelIndexServiceModel>(this.mapper.ConfigurationProvider)
            .Take(3);

        public async Task<List<HotelCategoryViewModel>> GetHotelCategories()
        => await this.context
               .Categories
               .ProjectTo<HotelCategoryViewModel>(this.mapper.ConfigurationProvider)
               .ToListAsync();

        public async Task<bool> ExistsByIdAsync(string hotelId)
        {
            bool result = await this.context
                .Hotels
                .AnyAsync(h => h.Id.ToString() == hotelId);

            return result;
        }

        /* public async Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync()
         {
             return await this.context.Hotels.Select(h => new HotelViewModel()
             {
                 Id = h.Id,
                 Category = h.Category.Name,
                 Description = h.Description,
                 ImageUrl = h.ImageUrl,
                 Name = h.Name
             }).ToListAsync();
         }*/

        /* public async Task<HotelDetailsViewModel?> GetDetailsAsync(int id)
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
                     User = p.User.Email
                 })
                  .FirstOrDefaultAsync();
         }*/


        /*public IEnumerable<HotelIndexServiceModel> LastThreeHotels()
            =>this.context.Hotels.OrderByDescending(h => h.Id)
                .Select(h => new HotelIndexServiceModel
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Name = h.Name
                })
                .Take(3);*/
    }
}
