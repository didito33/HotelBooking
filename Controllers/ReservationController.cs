using HotelBooking.Data.Entities;
using HotelBooking.Models.Room;
using HotelBooking.Services.Reservations;
using HotelBooking.Services.Rooms;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IRoomService roomService;
        private readonly IReservationService reservationService;
        public ReservationController(UserManager<User> userManager,IRoomService roomService,IReservationService reservationService)
        {
            this.userManager = userManager;
            this.roomService = roomService;
            this.reservationService = reservationService;
        }

        public IActionResult Reserve()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Reserve(int id, ReserveRoomViewModel reserveRoom)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            /*if (!service.ValidateDates(reserveRoom.StartDate, reserveRoom.EndDate))
            {
                ModelState.AddModelError(String.Empty, "Invalid dates");
                return this.View();
            }*/

            var isReserved = this.reservationService.ReserveRoom(reserveRoom, this.userManager.GetUserId(User), id);

            if (!isReserved)
            {
                var roomCategory = this.roomService.GetRoom(id).RoomCategory;
                ModelState.AddModelError(String.Empty, $"All {roomCategory}s are reserved for this period of time.");
                return this.View();
            }

            return RedirectToAction("MyReservations", "Reservations");
        }
    }
}
