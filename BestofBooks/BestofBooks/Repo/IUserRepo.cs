using BestofBooks.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IUserRepo
    {
        /// <summary>
        /// Validates credentials. Returns the matched UserModel on success, null on failure.
        /// The caller (UserController) is responsible for building claims and signing in.
        /// </summary>
        Task<UserModel?> loginUser(string userName, string passWord);

        /// <summary>
        /// Fetches a single user by primary key — used to populate LoggedInUser
        /// from the cookie claim without loading every user in the database.
        /// </summary>
        Task<UserModel?> getUserById(int userId);

        /// <summary>
        /// Returns all users — used by the Admin page user list.
        /// </summary>
        Task<List<UserModel>> getUsers();

        /// <summary>
        /// Creates a new user account. New accounts default to is_ViewOnly = true.
        /// </summary>
        Task<UserModel> createUser(UserModel newUser, string modifiedBy);

        /// <summary>
        /// Updates a single permission flag for a user by id.
        /// updateField is the column name; newValue is 1 (true) or 0 (false).
        /// </summary>
        Task updateUserRights(int BoBuser_id, string updateField, int newValue, string modifiedBy);

        /// <summary>
        /// Returns distinct usernames for the Change History Report filter dropdown.
        /// </summary>
        Task<List<SelectListItem>> getUserNames();

        /// <summary>
        /// Returns distinct last names for the Change History Report filter dropdown.
        /// </summary>
        Task<List<SelectListItem>> getUserLastNames();
    }
}