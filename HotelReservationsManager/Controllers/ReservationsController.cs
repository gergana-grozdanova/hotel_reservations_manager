using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelReservationsManager.Data;
using HotelReservationsManager.Data.Entities;
using HotelReservationsManager.Services.Reservations;
using HotelReservationsManager.Services.Clients;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using HotelReservationsManager.Services.Rooms;
using HotelReservationsManager.Dtos.Clients;
using HotelReservationsManager.Models;
using HotelReservationsManager.Dtos.Reservations;

namespace HotelReservationsManager.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IClientsService _clientsService;
        private readonly IRoomsService _roomsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(IReservationService reservationService, IClientsService clientsService,IRoomsService roomsService , UserManager<ApplicationUser> userManager)
        {
            _reservationService = reservationService;
            _clientsService = clientsService;
            _userManager = userManager;
            _roomsService = roomsService;
        }

        // GET: Reservations
        public async Task<IActionResult> All(int id = 1)
        {
            if (_reservationService.GetCount().GetAwaiter().GetResult() == 0)
            {
                return NotFound();
            }

            const int itemsPerPage = 2;
            var reservations = await _reservationService.GetAllPaginatedAsync(id, itemsPerPage);
            var model = new AllReservationsViewModel()
            {
                CurrentPage = id,
                Reservations = reservations,
                Count = await _clientsService.GetCount(),
                ItemsPerPage = itemsPerPage,
            };
            return View(model);
        }


        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            var reservation= await _reservationService.GetByIdAsync(id);
            if (reservation==null)
            {
                return NotFound();
            }
            Console.WriteLine("clientiteeeeeee");
            Console.WriteLine(reservation.Clients.Count);
            return View(reservation);
        }

        // GET: Reservations/Create
        public async  Task<IActionResult> Create(string id)
        {
            var room=  _roomsService.GetByIdAsync(id).GetAwaiter().GetResult();
 
            var model = new InputReservationDto()
            {
         
                Clients=new InputClientDto[room.Capacity]
                
            };
           
            return View(model);
        }

        // POST: Reservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string id, InputReservationDto reservation)
        {
            var room = _roomsService.GetByIdAsync(id).GetAwaiter().GetResult();
            ApplicationUser applicationUser = await _userManager.GetUserAsync(User);


            if (ModelState.IsValid)
            {
             await  _reservationService.CreateAsync(reservation,room,applicationUser);
                
            }
            return RedirectToAction("All");
        }

       

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation != null)
            {
                var room = reservation.Room;
                room.IsAvaible = true;
               await _roomsService.UpdateAsync(room);
              await  _reservationService.DeleteAsync(id);

                
            }

            return RedirectToAction("All");
        }


    }
}
