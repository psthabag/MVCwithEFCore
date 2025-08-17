using System.ComponentModel.DataAnnotations;

namespace MVCwithEFCore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        public string Publisher { get; set; }
        [Required]
        [Range(1980,2025, ErrorMessage = "Year must be between 1980 and 2025")]
        public int YearPublished { get; set; }
        public string ISBN { get; set; }
    }
}
