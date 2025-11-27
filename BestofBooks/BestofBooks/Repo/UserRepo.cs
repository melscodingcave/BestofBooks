using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using BestofBooks.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace BestofBooks.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly IConfiguration _config;

        public UserRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<UserModel>> getUsers()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> users = (await dbConnection.QueryAsync<UserModel>("GetUserList", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return users;
        }

        public async Task<List<UserModel>> getChangeHistory()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> chUsers = (await dbConnection.QueryAsync<UserModel>("GetChangeReport", new { }, commandType: CommandType.StoredProcedure)).ToList(); //throwing error

            return chUsers;
        }

        public async Task<UserModel> createUser(UserModel newUser, string modifiedBy)
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            object[] parameters =
            {
                new
                {
                    user_last = newUser.user_last,
                    user_first = newUser.user_first,
                    user_email = newUser.user_email,
                    username = newUser.username,
                    password = newUser.password,
                    user_type = newUser.user_type,
                    adds_enabled = newUser.adds_enabled,
                    edits_enabled = newUser.edits_enabled,
                    deletes_enabled = newUser.deletes_enabled,
                    is_admin = newUser.is_Admin,
                    is_ViewOnly = newUser.is_ViewOnly,
                    modifiedBy = modifiedBy
                }
            };
            await dbConnection.ExecuteAsync("CreateNewUser", param: parameters, commandType: CommandType.StoredProcedure);

            return newUser;
        }

        public async Task updateUserRights(int BoBuser_id, string updateField, int newValue, string modifiedBy)
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            var parameters = new DynamicParameters();
            parameters.Add("BoBuser_id", BoBuser_id);
            parameters.Add(updateField, newValue);
            parameters.Add("modifiedBy", modifiedBy);
            await dbConnection.ExecuteAsync("UpdateRights", param: parameters, commandType: CommandType.StoredProcedure);

            return;
        }

        public async Task<bool> loginUser(string userName, string password, HttpContext context)
        {
            List<UserModel> users = await getUsers();
            var user = users.FirstOrDefault(u => u.username.ToLower() == userName.ToLower());
            if (user == null)
            {
                return false;
            }
            bool success = SecurityUtilities.userLoggedIn(user.password, password);
            if (success)
            {
                context.Session.SetInt32("_loggedInUser", user.BoBuser_id);
            }
            else
            {
                context.Session.SetInt32("_loggedInUser", 0);
            }
            return success;
        }
        public async Task<List<SelectListItem>> getUserNames()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> userName = (await dbConnection.QueryAsync<UserModel>("SELECT username FROM dbo.BoBUser")).ToList();

            return UserNameToSelectListItems(userName);
        }
        private List<SelectListItem> UserNameToSelectListItems(IEnumerable<UserModel> users)
        {
            return users
                .Select(l => new SelectListItem
                {
                    Text = l.username,
                })
                .ToList();
        }

        public async Task<List<SelectListItem>> getUserLastNames()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<UserModel> userLastName = (await dbConnection.QueryAsync<UserModel>("SELECT user_last FROM dbo.BoBUser")).ToList();

            return UserLastNameToSelectListItems(userLastName);
        }
        private List<SelectListItem> UserLastNameToSelectListItems(IEnumerable<UserModel> users)
        {
            return users
                .Select(l => new SelectListItem
                {
                    Text = l.user_last,
                })
                .ToList();
        }
    }

}

