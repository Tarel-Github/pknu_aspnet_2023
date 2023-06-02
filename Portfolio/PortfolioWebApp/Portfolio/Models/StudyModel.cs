using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class StudyModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "타이틀은 필수입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }


        [DisplayName("프로젝트 URL")]
        public string? Url { get; set; }


        [DisplayName("현재 시각")]
        public DateTime CurrentTime { get; set; }
    }
}
