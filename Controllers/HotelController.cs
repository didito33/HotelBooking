using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
            => View(new AllHotelsQueryModel());

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.service.GetDetailsAsync(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }
    }
}
