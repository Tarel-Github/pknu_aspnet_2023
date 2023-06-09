﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Portfolio.Models
{
    // 회원가입할 때 데이터 받는 부분
    public class RegisterModel
    {
        [Required(ErrorMessage = "이메일은 필수입니다.")]
        [EmailAddress]
        [DisplayName("이메일주소")]
        public string Email { get; set; }


        [Required(ErrorMessage = "닉네임은 필수입니다.")]
        [DataType(DataType.Text)]
        [DisplayName("닉네임")]
        public string Nickname { get; set; }


        [Required(ErrorMessage = "패스워드는 필수입니다.")]
        [DataType(DataType.Password)]
        [DisplayName("패스워드")]
        public string Password { get; set; }


        [Required(ErrorMessage = "패스워드 확인은 필수입니다.")]
        [DataType(DataType.Password)]
        [DisplayName("패스워드 확인")]
        [Compare("Password", ErrorMessage = "패스워드가 일치하지 않습니다. 다시 입력하세요.")]
        public string ConfirmPassword { get; set; }
    }
}
