using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PortfolioWebController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public PortfolioWebController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _db.PortfolioWeb.ToList(); //SELECT *
            return View(list);
        }

        // 새 글 작성
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PortfolioWebModel temp)
        {
            var model = new PortfolioWebModel()
            {
                Title = temp.Title,
                Url = temp.Url
            };

            _db.PortfolioWeb.Add(model);
            _db.SaveChanges();

            TempData["succeed"] = "포트폴리오 저장완료!";
            return RedirectToAction("Index", "PortfolioWeb");

        }
    }
}
