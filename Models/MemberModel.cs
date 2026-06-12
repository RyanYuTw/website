using System;
using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "帳號為必填")]
        [StringLength(50)]
        public string Account { get; set; }
        [Required(ErrorMessage = "密碼為必填")]
        public string Password { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Email 格式不正確")]
        public string Email { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        // B2B = 經銷商, B2C = 一般會員, Admin = 管理員
        public string Kind { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "請輸入帳號")]
        public string Account { get; set; }
        [Required(ErrorMessage = "請輸入密碼")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "帳號為必填")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "帳號長度須介於 4-50 字元")]
        public string Account { get; set; }
        [Required(ErrorMessage = "密碼為必填")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "密碼長度須介於 6-100 字元")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "請再次輸入密碼")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "兩次密碼輸入不一致")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "姓名為必填")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email 為必填")]
        [EmailAddress(ErrorMessage = "Email 格式不正確")]
        public string Email { get; set; }
        [Required(ErrorMessage = "手機為必填")]
        public string Mobile { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "請輸入舊密碼")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "請輸入新密碼")]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "請再次輸入新密碼")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "兩次密碼輸入不一致")]
        public string ConfirmPassword { get; set; }
    }
}
