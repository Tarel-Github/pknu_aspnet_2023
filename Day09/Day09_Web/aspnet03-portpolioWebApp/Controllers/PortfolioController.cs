using aspnet02_boardapp.Data;
using aspnet03_portpolioWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace aspnet03_portpolioWebApp.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _db;

        private readonly IWebHostEnvironment _environment;

        public PortfolioController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var list = _db.Portfolios.ToList(); //SELECT *
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {   // 뷰 추가할 때, PortfolioModel(X) --> TempPortfolioModel(O)
            return View();
        }

        [HttpPost]
        public IActionResult Create(TempPortfolioModel temp)
        {
            // 파일업로드, Temp -> Model db저장
            if (ModelState.IsValid)
            {
                // 파일업로드
                string upFileName = UploadImageFile(temp);

                // TempPortfolioModel -> PortfolioModel 변경
                var portfolio = new PortfolioModel()
                {
                    Division = temp.Division,
                    Title = temp.Title,
                    Description = temp.Description,
                    Url = temp.Url,
                    FileName = upFileName   // 이게 핵심
                };

                _db.Portfolios.Add(portfolio);
                _db.SaveChanges();

                TempData["succeed"] = "포트폴리오 저장완료!";
                return RedirectToAction("Index", "Portfolio");
            }
            return View(temp);
        }

        // 라우팅이나 Get/Post랑 관계없음
        private string UploadImageFile(TempPortfolioModel temp)
        {
            var resultFileName = "";

            try
            {
                if (temp.PortfolioImage != null)
                {
                    // "portfolio01.png"
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");    // wwwroot 밑에 uploads라는 폴더 존재
                    resultFileName = Guid.NewGuid() + "_" + temp.PortfolioImage.FileName;       // 중복된 이미지 파일명 제거
                    string filePath = Path.Combine(uploadFolder, resultFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        temp.PortfolioImage.CopyTo(fileStream);
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.Write(ex.Message);
            }

            return resultFileName;
        }
    }
}
