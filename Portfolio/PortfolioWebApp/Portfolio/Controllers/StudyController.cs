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

        // 새 글 작성
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(StudyModel temp)
        {
            // 이부분 주석 해제해야함
            // TempPortfolioModel -> PortfolioModel 변경
            //var portfolio = new StudyModel()
            //{
            //    Title = temp.Title,
            //    Url = temp.Url
            //};

            //_db.Study.Add(portfolio);
            //_db.SaveChanges();

            //TempData["succeed"] = "포트폴리오 저장완료!";
            return RedirectToAction("Index", "Portfolio");
            
        }



    }
}
