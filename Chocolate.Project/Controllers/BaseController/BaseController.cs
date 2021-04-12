using Microsoft.AspNetCore.Mvc;

namespace ChocolateProject.Controllers
{
    public abstract class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}