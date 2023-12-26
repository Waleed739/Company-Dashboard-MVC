﻿using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class ForgetPasswordVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
