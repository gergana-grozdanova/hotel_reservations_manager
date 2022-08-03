using HotelReservationsManager.Dtos;
using HotelReservationsManager.Models;
using HotelReservationsManager.Services.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelReservationsManager.WebConstants;

namespace HotelReservationsManager.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService _roomsService;
        public RoomsController(IRoomsService roomsService)
        {
            _roomsService= roomsService;
        }

        [Authorize(Roles =AdminRoleName)]
        public IActionResult Create()
        {
            Console.WriteLine(User.IsInRole(AdminRoleName));
            if (!User.IsInRole(AdminRoleName))
            {
                //TODO: check if it works
                return this.RedirectToAction("Login", "Identity");
            }

            var model = new RoomDto()
            {

            };
            return View(model);
        }

        [Authorize(Roles = AdminRoleName)]
        [HttpPost]
        public async Task<IActionResult> Create(InputRoomDto input)
        {
            Console.WriteLine(this.ModelState.IsValid);
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }

             await _roomsService.CreateAsync(input);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> All(int id=1)
        {
            const int itemsPerPage= 2;
           var rooms= await _roomsService.GetAllAsync(id,itemsPerPage);
            var model = new AllRoomsViewModel()
            {
                CurrentPage=id,
                Rooms = rooms,
                Count = await _roomsService.GetCount(),
                ItemsPerPage=itemsPerPage,
            };
            return View(model);
        }
        
        [Authorize(Roles = AdminRoleName)]
        public async  Task<IActionResult> Delete(string id)
        {
            await _roomsService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            var room = await _roomsService.GetByIdAsync(id);
            
            return View(room);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async  Task<IActionResult> Edit(RoomDto input)
        {
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }
            await _roomsService.UpdateAsync(input);
            return RedirectToAction("Index", "Home");
        }
    }
}
