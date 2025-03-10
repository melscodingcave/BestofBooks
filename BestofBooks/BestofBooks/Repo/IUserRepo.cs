using BestofBooks.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IUserRepo
    {
        Task<UserModel> createUser(UserModel newUser, string modifiedBy);
        Task<List<UserModel>> getChangeHistory();
        Task<List<SelectListItem>> getUserLastNames();
        Task<List<SelectListItem>> getUserNames();
        Task<List<UserModel>> getUsers();
        Task<bool> loginUser(string userName, string passWord, HttpContext context);
        Task updateUserRights(int BoBuser_id, string updateField, int newValue, string modifiedBy);
    }
}