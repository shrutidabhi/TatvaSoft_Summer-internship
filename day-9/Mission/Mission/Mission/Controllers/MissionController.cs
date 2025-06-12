using Microsoft.AspNetCore.Mvc;

namespace Mission.Controllers
{
    public class MissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
