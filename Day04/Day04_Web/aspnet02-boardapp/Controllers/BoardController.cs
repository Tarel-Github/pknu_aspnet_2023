using aspnet02_boardapp.Data;
using aspnet02_boardapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet02_boardapp.Controllers
{
    // https://localhost:7800/Board/Index
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BoardController(ApplicationDbContext db)
        {
            _db = db;   // 알아서 DB가 연결됌
        }


        public IActionResult Index()
        {
            IEnumerable<Board> objBoardList = _db.Boards.ToList();   // SELECT 쿼리
            return View(objBoardList);
        }

        // https://localhost:7125/Board/Create
        // GetMethod로 만드는 액션

        [HttpGet]

        public IActionResult Create() // 게시판 글쓰기
        {
            return View();
        }
        // Submit이 발생해서 내부로 데이터를 전달

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Board board)
        {
            _db.Boards.Add(board); // INSERT
            _db.SaveChanges(); // COMMINT
            
            return RedirectToAction("Index", "Board");
        }



    }
}
