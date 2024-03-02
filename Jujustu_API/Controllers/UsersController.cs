using Microsoft.AspNetCore.Mvc;

namespace Jujustu_API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
