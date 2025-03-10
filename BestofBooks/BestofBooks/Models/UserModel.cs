using System;
namespace BestofBooks.Models
{
    public class UserModel
    {
        public int BoBuser_id { get; set; }
        public string user_first { get; set; }
        public string user_last { get; set; }
        public string user_email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string user_type { get; set; }
        public bool adds_enabled { get; set; }
        public bool edits_enabled { get; set; }
        public bool deletes_enabled { get; set; }
        public bool is_Admin { get; set; }
        public bool is_ViewOnly { get; set; }
    }

}