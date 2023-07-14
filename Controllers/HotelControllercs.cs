using HotelBooking.Models.Hotel;

using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class HotelControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult All()
            => View(new AllHotelsQueryModel());
        public IActionResult Details(int id)
            => View(new HotelDetailsViewModel());
    }
}
