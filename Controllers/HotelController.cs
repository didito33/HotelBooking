using HotelBooking.Models.Hotel;
using HotelBooking.Services.Hotels;
using HotelBooking.Services.Rooms;
using HotelBooking.ViewModels.Hotel;
using HotelBooking.ViewModels.Room;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService service;
        private readonly IRoomService roomService;
        public HotelController(IHotelService service, IRoomService roomService)
        {
            this.service = service;
            this.roomService = roomService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            var models = await service.GetAllHotelsAsync();
            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.service.GetDetailsAsync(id);

            if (model == null)
            {
                return BadRequest();
            }
            FilterRoomsViewModel filterModel = new FilterRoomsViewModel();
            if (TempData["CityId"] != null) 
            {
                filterModel.StartDate = DateTime.Parse(TempData["StartDate"].ToString());
                filterModel.EndDate = DateTime.Parse(TempData["EndDate"].ToString());
                filterModel.CountOfPeople = (int)TempData["CountOfPeople"];
                filterModel.CityId = (int)TempData["CityId"];
            }
            this.ViewBag.Rooms = this.roomService.GetAllRoomsByHotel(id, filterModel);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool hotelExists = await this.service
                .ExistsByIdAsync(id);

            if (!hotelExists)
            {
                return this.RedirectToAction("All", "House");
            }

            try
            {
                HotelEditViewModel formModel = await this.service
                    .GetHotelForEditByIdAsync(id);

                formModel.Categories = await this.service.GetHotelCategories();

                return this.View(formModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, HotelEditViewModel model)
        {
            bool houseExists = await this.service
                .ExistsByIdAsync(id);

            if (!houseExists)
            {
                return this.RedirectToAction("All", "House");
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.service.GetHotelCategories();

                return this.View(model);
            }

            try
            {
                await this.service.EditHotelByIdAsync(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty,
                    "Unexpected error occurred while trying to update the hotel. Please try again later or contact administrator!");

                model.Categories = await this.service.GetHotelCategories();

                return this.View(model);
            }

            return this.RedirectToAction("Details", "Hotel", new { id });
        }

    }
}
