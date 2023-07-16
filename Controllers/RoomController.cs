using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
using HotelBooking.Services.Rooms;

using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }
        public IActionResult Add() => this.View(new AddRoomViewModel
        {
            RoomCategories = this.roomService.GetRoomCategories()
        });
        /*public async Task<IActionResult> Add()
        {
            var model = new AddRoomViewModel()
            {
                model.RoomCategories = await roomService.GetRoomCategories()
            };
            return View(model);
        }*/

        //[HttpPost]
        /*public async Task<IActionResult> Add(int id, AddRoomViewModel roomModel)
        {
            if (!ModelState.IsValid)
            {
                roomModel.RoomCategories = this.roomService.GetRoomCategories();
                return this.View(roomModel);
            }

            roomModel.HotelId = id;

            await this.roomService.AddRoom(roomModel);


            return this.View(roomModel);
        }*/


    }
}
