using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BestofBooks.Models
{
    public class AdminModel
    {
        public List<SelectListItem> listAdmins { get; set; }
        public UserModel admins { get; set; }
        public UserModel newAdmin { get; set; }
    }
}
