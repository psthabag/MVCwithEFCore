using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCwithEFCore.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
