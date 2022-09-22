using HotelReservationsManager.Dtos.Clients;
using HotelReservationsManager.Models;
using HotelReservationsManager.Services.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelReservationsManager.WebConstants;

namespace HotelReservationsManager.Controllers
{
    [Authorize(Roles = AdminRoleName)]

    public class ClientsController : Controller
    {
        private readonly IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            if (!User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("/Account/Login", "Identity");
            }

            var model = new InputClientDto()
            {

            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InputClientDto input)
        {
            Console.WriteLine(this.ModelState.IsValid);
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }

            await _clientsService.CreateAsync(input);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> All(int id = 1)
        {
            const int itemsPerPage = 2;
            var clients = await _clientsService.GetAllPaginatedAsync(id, itemsPerPage);
            var model = new AllClientsViewModel()
            {
                CurrentPage = id,
                Clients = clients,
                Count = await _clientsService.GetCount(),
                ItemsPerPage = itemsPerPage,
            };
            return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _clientsService.DeleteAsync(id);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(string id)
        {
            var room = await _clientsService.GetByIdAsync(id);

            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientDto input)
        {
            if (!this.ModelState.IsValid)
            {
                return View(input);
            }
            await _clientsService.UpdateAsync(input);
            return RedirectToAction("Index", "Home");
        }
    }
}
