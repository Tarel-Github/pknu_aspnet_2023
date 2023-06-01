using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerDashBoard()
        {
            return View();
        }

        public IActionResult Announcement()
        {
            return View();
        }
        
        public IActionResult Portfolio_01()
        {
            return View();
        }

        public IActionResult Portfolio_02()
        {
            return View();
        }

        public IActionResult Service()
        {
            return View();
        }

        public IActionResult Study() 
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}
