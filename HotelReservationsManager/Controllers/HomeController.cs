using HotelReservationsManager.Models;
using HotelReservationsManager.Models.Home;
using HotelReservationsManager.Services.Rooms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservationsManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomsService _roomsService;

        public HomeController(ILogger<HomeController> logger,IRoomsService roomsService)
        {
            _logger = logger;
            _roomsService = roomsService;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                FreeRoomsCount = _roomsService.GetFreeRoomsCount()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}