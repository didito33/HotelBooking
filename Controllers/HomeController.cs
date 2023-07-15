using HotelBooking.Models;
using HotelBooking.Services.Hotels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelBooking.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHotelService hotels;
        public HomeController(IHotelService hotels)
        {
            this.hotels = hotels;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var hotels = this.hotels.LastThreeHotels();
            return View(hotels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}