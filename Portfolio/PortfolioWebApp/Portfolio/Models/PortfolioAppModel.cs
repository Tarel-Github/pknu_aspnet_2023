using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class PortfolioAppModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "타이틀은 필수입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }


        [Required(ErrorMessage = "깃허브 주소는 필수입니다..")]
        [DisplayName("깃허브 주소")]
        public string Url { get; set; }


        [NotMapped]
        [DisplayName("파일명(585 x 400) 권장")]    // 실제 이미지를 받아서 저장하기 위한 중간단계 객체!
        public IFormFile? PortfolioImage { get; set; }

    }
}
