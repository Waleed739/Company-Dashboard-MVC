using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(6,MinimumLength =6)]
        public string PassWord { get; set; }
        [Required]
        [Compare("PassWord", ErrorMessage="Password MissMatch")]
        [StringLength(6, MinimumLength = 6)]
        public string ConfirmPassWord { get; set; }
        [Required]
        public bool IsAgree { get; set; }
    }
}
