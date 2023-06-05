using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public AnnouncementController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()//Index를 Announcement로 바꾸어보았지만 안 됌
        {
            var list = _db.Announcement.ToList(); //SELECT *
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["NoScroll"] = "true";  // 게시판은 메인스크롤이 안생김

            return View();
        }

        [HttpPost]
        public IActionResult Create(AnnouncementModel temp)
        {
            var announcement = new AnnouncementModel()
            {
                Title = temp.Title,
                Detail = temp.Detail
            };

            _db.Announcement.Add(announcement);
            _db.SaveChanges();

            TempData["succeed"] = "공지사항 저장완료!";
            return RedirectToAction("Announcement", "Home");

        }
    }
}
