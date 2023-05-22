using System.ComponentModel.DataAnnotations;

namespace aspnet02_boardapp.Models
{
    // 게시판을 위한 테이블 매핑 정보
    public class Board
    {
        [Key]   // PK
        public int Id { get; set; }
        [Required(ErrorMessage = "아이디를 입력하세요"))]  // Not Null
        public string UserId { get; set; }
        public string? UserName { get; set; }   // 물음표 붙여서 Null 허용
        [Required(ErrorMessage ="제목을 입력하세요")]  // Not Null
        [MaxLength(200)]    // ==Varchar(200)
        public string Title { get; set; }
        public int ReadCount { get; set; }
        public DateTime PostDate { get; set; }
        public string Contents { get; set; }

    }
}
