using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace PL.Models
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }

        public DateTime DateOfHiring { get; set; } = DateTime.Now;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public bool IsActive { get; set; }
    }
}
