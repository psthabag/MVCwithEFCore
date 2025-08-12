using System.ComponentModel.DataAnnotations;

namespace MVCwithEFCore.Models
{
    public class Subject
    {
        [Key]
        public int SubId { get; set; }
        [Required]
        public string SubName { get; set; }
        [Required]
        public int Credits { get; set; }
        public string Category { get; set; }
    }
}
