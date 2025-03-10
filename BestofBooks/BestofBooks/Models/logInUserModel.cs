using System.ComponentModel.DataAnnotations;

namespace BestofBooks.Models
{
    public class LogInUserModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
