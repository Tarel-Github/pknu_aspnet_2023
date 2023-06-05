using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class PortfolioAppController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;

        public PortfolioAppController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _db.PortfolioApp.ToList(); //SELECT *
            return View(list);
        }

        // 새 글 작성
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PortfolioAppModel temp)
        {
            var model = new PortfolioAppModel()
            {
                Title = temp.Title,
                Url = temp.Url
            };

            _db.PortfolioApp.Add(model);
            _db.SaveChanges();

            TempData["succeed"] = "포트폴리오 저장완료!";
            return RedirectToAction("Index", "PortfolioApp");

        }
    }
}
