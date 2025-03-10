using System.ComponentModel.DataAnnotations;

namespace BestofBooks.Models
{
    public class updateUserModel
    {
        [Required]
        public int BoBuser_id { get; set; }
        public bool? adds_enabled { get; set; }
        public bool? edits_enabled { get; set; }
        public bool? deletes_enabled { get; set; }
        public bool? is_ViewOnly { get; set; }
        public bool? is_Admin { get;set; }
    }
}
