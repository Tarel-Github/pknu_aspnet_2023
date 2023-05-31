using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class Board
    {
        [Key] // PK
        public int Id { get; set; }


        [Required(ErrorMessage = "아이디를 입력하세요")] // Not Null
        [DisplayName("아이디")]
        public string UserId { get; set; }


        [DisplayName("이름")]
        public string? UserName { get; set; } // Null 허용


        [Required(ErrorMessage = "제목을 입력하세요")] // Not Null
        [MaxLength(200)] // == Varchar(200)
        [DisplayName("제목")]
        public string Title { get; set; }


        [DisplayName("조회")]
        public int ReadCount { get; set; }


        [DisplayName("작성일")]
        public DateTime PostDate { get; set; }


        [DisplayName("게시글")]
        public string Contents { get; set; }
        
    }
}
