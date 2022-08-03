using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HotelReservationsManager.WebConstants;

namespace HotelReservationsManager.Controllers
{
    [Authorize(Roles = AdminRoleName)]

    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
