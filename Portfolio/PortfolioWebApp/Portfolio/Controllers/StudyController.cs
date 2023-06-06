using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class StudyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public StudyController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()//Index를 Announcement로 바꾸어보았지만 안 됌
        {
            var list = _db.Study.ToList(); //SELECT *
            return View(list);
        }

        // 새 글 작성
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(StudyModel temp)
        {
            var portfolio = new StudyModel()
            {
                Title = temp.Title,
                Url = temp.Url,
                CreatedAt = DateTime.Now // 현재 시각 추가
            };

            _db.Study.Add(portfolio);
            _db.SaveChanges();

            TempData["succeed"] = "스터디 저장완료!";
            return RedirectToAction("Index", "Study");

        }



    }
}
