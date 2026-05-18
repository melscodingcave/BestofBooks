using BestofBooks.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public class UserRepo : IUserRepo
    {
        // Connection string retrieved once at construction, not on every method call
        private readonly string _connString;

        public UserRepo(IConfiguration config)
        {
            _connString = config.GetConnectionString("BestofBooks");
        }

        // ── Helper: opens a connection from the shared connection string ──────
        private IDbConnection Connect() => new SqlConnection(_connString);

        // ── LOGIN ─────────────────────────────────────────────────────────────

        public async Task<UserModel?> loginUser(string userName, string password)
        {
            // Targeted query — fetch only the one user by username.
            // No longer loads the entire user table into memory.
            using var db = Connect();
            var user = await db.QueryFirstOrDefaultAsync<UserModel>(
                "SELECT * FROM dbo.BoBUser WHERE username = @userName",
                new { userName });

            if (user is null) return null;

            bool valid = SecurityUtilities.userLoggedIn(user.password, password);
            if (!valid) return null;

            // If the stored hash is in the old SHA256 format (no colon separator),
            // silently upgrade it to PBKDF2 on successful login.
            // Once all passwords are upgraded this block becomes unreachable.
            if (!user.password.Contains(':'))
            {
                user.password = SecurityUtilities.HashPassword(password);
                await db.ExecuteAsync(
                    "UPDATE dbo.BoBUser SET password = @password WHERE BoBuser_id = @id",
                    new { password = user.password, id = user.BoBuser_id });
            }

            return user;
        }

        // ── GET USER BY ID ────────────────────────────────────────────────────

        public async Task<UserModel?> getUserById(int userId)
        {
            // Used by HomeController.GetLoggedInUserAsync() — single targeted
            // lookup from the cookie claim instead of scanning all users.
            using var db = Connect();
            return await db.QueryFirstOrDefaultAsync<UserModel>(
                "SELECT * FROM dbo.BoBUser WHERE BoBuser_id = @userId",
                new { userId });
        }

        // ── GET ALL USERS ─────────────────────────────────────────────────────

        public async Task<List<UserModel>> getUsers()
        {
            using var db = Connect();
            var users = await db.QueryAsync<UserModel>(
                "GetUserList",
                commandType: CommandType.StoredProcedure);
            return users.ToList();
        }

        // ── CREATE USER ───────────────────────────────────────────────────────

        public async Task<UserModel> createUser(UserModel newUser, string modifiedBy)
        {
            using var db = Connect();

            // Plain anonymous object — no need for object[] wrapping
            await db.ExecuteAsync("CreateNewUser", new
            {
                newUser.user_last,
                newUser.user_first,
                newUser.user_email,
                newUser.username,
                newUser.password,
                newUser.user_type,
                newUser.adds_enabled,
                newUser.edits_enabled,
                newUser.deletes_enabled,
                is_admin = newUser.is_Admin,
                newUser.is_ViewOnly,
                modifiedBy
            },
            commandType: CommandType.StoredProcedure);

            return newUser;
        }

        // ── UPDATE USER RIGHTS ────────────────────────────────────────────────

        public async Task updateUserRights(int BoBuser_id, string updateField,
                                           int newValue, string modifiedBy)
        {
            using var db = Connect();
            var p = new DynamicParameters();
            p.Add("BoBuser_id", BoBuser_id);
            p.Add(updateField, newValue);
            p.Add("modifiedBy", modifiedBy);
            await db.ExecuteAsync("UpdateRights", p,
                commandType: CommandType.StoredProcedure);
        }

        // ── DROPDOWN HELPERS ──────────────────────────────────────────────────

        public async Task<List<SelectListItem>> getUserNames()
        {
            using var db = Connect();

            // DISTINCT prevents duplicate entries in the dropdown.
            // Value is set so the POST model binding receives the actual username,
            // not an empty string (the original was missing Value entirely).
            var names = await db.QueryAsync<string>(
                "SELECT DISTINCT username FROM dbo.BoBUser ORDER BY username");

            return names.Select(n => new SelectListItem
            {
                Text = n,
                Value = n
            }).ToList();
        }

        public async Task<List<SelectListItem>> getUserLastNames()
        {
            using var db = Connect();

            var lastNames = await db.QueryAsync<string>(
                "SELECT DISTINCT user_last FROM dbo.BoBUser ORDER BY user_last");

            return lastNames.Select(n => new SelectListItem
            {
                Text = n,
                Value = n
            }).ToList();
        }
    }
}