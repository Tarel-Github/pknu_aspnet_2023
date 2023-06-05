using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class AnnouncementModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "타이틀은 필수입니다.")]
        [DisplayName("제목")]
        public string Title { get; set; }

        [Required(ErrorMessage = "설명은 필수입니다.")]
        [DisplayName("내용")]
        public string Detail { get; set; }
    }
}
