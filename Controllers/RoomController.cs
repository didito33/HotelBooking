using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
using HotelBooking.Services.Rooms;

using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomController : BaseController
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            AddRoomViewModel model = new AddRoomViewModel()
            {
                RoomCategories = await this.roomService.GetRoomCategories()
            };

            model.UserId = GetUserId();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoomViewModel roomModel)
        {
            bool roomCategoryExists = await this.roomService.RoomCategoryExistsByIdAsync(roomModel.RoomCategoryId);

            if (!roomCategoryExists)
            {
                ModelState.AddModelError(nameof(roomModel.RoomCategoryId), "Selected room category does not exist!");
            }

            if (!ModelState.IsValid)
            {
                roomModel.RoomCategories = await this.roomService.GetRoomCategories();

                return this.View(roomModel);
            }

            await this.roomService.AddRoomAsync(roomModel);

            return this.View(roomModel);
        }
        public IActionResult Details(int id)
        {
            var room = this.roomService.GetRoom(id);

            if (room == null)
            {
                RedirectToAction("All", "Hotels");
            }

            return this.View(room);
        }

    }
}
