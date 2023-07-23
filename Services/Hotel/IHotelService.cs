using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels.Models;
using HotelBooking.Services.Models;
using HotelBooking.ViewModels.Hotel;
using HotelBooking.ViewModels.HotelCategory;

namespace HotelBooking.Services.Hotels
{
    public interface IHotelService
    {
        IEnumerable<HotelIndexServiceModel> LastThreeHotels();
        Task<IEnumerable<HotelViewModel>> GetAllHotelsAsync();
        Task<HotelDetailsViewModel?> GetDetailsAsync(int id);
        Task<HotelEditViewModel> GetHotelForEditByIdAsync(string houseId);
        Task EditHotelByIdAsync(string hotelId, HotelEditViewModel formModel);
        Task<List<HotelCategoryViewModel>> GetHotelCategories();
        Task<bool> ExistsByIdAsync(string hotelId);
    }
}
