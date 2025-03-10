using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BestofBooks.Models.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public List<UserModel> listUsers { get; set; }  
        public List<SelectListItem> chUserNames { get; set; }
        public List<SelectListItem> chUserLast { get; set; }
    }
}
