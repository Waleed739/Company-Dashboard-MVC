using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ResetPasswordVM
    {
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string PassWord { get; set; }
        [Required]
        [Compare("PassWord", ErrorMessage = "Password MissMatch")]
        [StringLength(6, MinimumLength = 6)]
        public string ConfirmPassWord { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
