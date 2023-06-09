﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    public class PortfolioWebModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "타이틀은 필수입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }


        [Required(ErrorMessage = "깃허브 주소는 필수입니다..")]
        [DisplayName("깃허브 주소")]
        public string Url { get; set; }

        [Required(ErrorMessage = "내용은 필수입니다..")]
        [DisplayName("내용")]
        public string Detail { get; set; }


        [DisplayName("작성일")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("파일명")]
        [FileExtensions(Extensions = ".png,.jpg,.jpeg", ErrorMessage = "이미지 파일을 선택하세요.")]
        public string? FileName { get; set; }


    }


    public class TempPortfolioWebModel    // 파일 업로드를 위한 중간단계 모델
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "타이틀은 필수입니다.")]
        [DisplayName("타이틀")]
        public string Title { get; set; }

        [Required(ErrorMessage = "깃허브 주소는 필수입니다..")]
        [DisplayName("깃허브 주소")]
        public string Url { get; set; }

        [Required(ErrorMessage = "내용은 필수입니다..")]
        [DisplayName("내용")]
        public string Detail { get; set; }

        [DisplayName("작성일")]
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        [DisplayName("파일명(585 x 400) 권장")]    // 실제 이미지를 받아서 저장하기 위한 중간단계 객체!
        public IFormFile? PortfolioImage { get; set; }

        [DisplayName("파일명")]
        [FileExtensions(Extensions = ".png,.jpg,.jpeg", ErrorMessage = "이미지 파일을 선택하세요.")]
        public string? FileName { get; set; }
    }
}
