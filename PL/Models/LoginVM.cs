using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class LoginVM
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}
