using HotelBooking.Data.Entities;
using HotelBooking.ViewModels.HotelCategory;

namespace HotelBooking.ViewModels.Hotel
{
    public class HotelEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public ICollection<HotelCategoryViewModel> Categories { get; set; } = new List<HotelCategoryViewModel>();
    }
}
