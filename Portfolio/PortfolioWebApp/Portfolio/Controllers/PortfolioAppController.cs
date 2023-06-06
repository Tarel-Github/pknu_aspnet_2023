using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;
using System.Diagnostics;

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
        public IActionResult Create(TempPortfolioAppModel temp)
        {
            // 파일업로드 함수로 이동
            string upFileName = UploadImageFile(temp);

            var model = new PortfolioAppModel()
            {
                Title = temp.Title,
                Url = temp.Url,
                Detail = temp.Detail,
                CreatedAt = DateTime.Now,
                FileName = upFileName   // 이게 핵심
            };

            _db.PortfolioApp.Add(model);
            _db.SaveChanges();

            TempData["succeed"] = "포트폴리오 저장완료!";

            return RedirectToAction("Index", "PortfolioApp");
        }


        // 라우팅이나 Get/Post랑 관계없음
        private string UploadImageFile(TempPortfolioAppModel temp)
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
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            return resultFileName;
        }
    }
}
