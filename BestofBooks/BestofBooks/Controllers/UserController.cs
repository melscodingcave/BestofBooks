using BestofBooks.Models;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BestofBooks.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepo _userRepo;

        public UserController(ILogger<UserController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        // ── Convenience: current username straight from the auth cookie claim ──
        // No database round-trip. No session lookup. Zero cost.
        private string CurrentUsername =>
            User.FindFirstValue(ClaimTypes.Name) ?? "unauthorized";

        // ── LOGIN ─────────────────────────────────────────────────────────────

        [HttpPost]
        [Route("api/user/logIn")]
        [AllowAnonymous]
        public async Task<IActionResult> LogInUser([FromBody] LogInUserModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate credentials — repo returns the user or null
            var user = await _userRepo.loginUser(model.Username, model.Password);

            if (user is null)
                return Unauthorized(new { message = "Invalid username or password." });

            // Build claims from the user's permission flags
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,      user.username),
                new Claim("BoBuser_id",         user.BoBuser_id.ToString()),
                new Claim("is_Admin",           user.is_Admin.ToString().ToLower()),
                new Claim("edits_enabled",      user.edits_enabled.ToString().ToLower()),
                new Claim("adds_enabled",       user.adds_enabled.ToString().ToLower()),
                new Claim("deletes_enabled",    user.deletes_enabled.ToString().ToLower()),
                new Claim("is_ViewOnly",        user.is_ViewOnly.ToString().ToLower()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            _logger.LogInformation("User {Username} logged in.", user.username);
            return Ok(new { username = user.username });
        }

        // ── LOGOUT ────────────────────────────────────────────────────────────

        [HttpPost]
        [Route("api/user/logOut")]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            _logger.LogInformation("User {Username} logged out.", CurrentUsername);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { });
        }

        // ── PERMISSION UPDATES (admin only) ───────────────────────────────────
        // [Authorize(Policy = "RequireAdmin")] blocks non-admins at the framework
        // level — no manual if-checks needed inside the action body.

        [HttpPut]
        [Route("api/user/updateAddRights")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateAddRights([FromBody] updateUserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "adds_enabled",
                model.adds_enabled.Value ? 1 : 0, CurrentUsername);
            return Ok(new { });
        }

        [HttpPut]
        [Route("api/user/updateEditRights")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateEditRights([FromBody] updateUserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "edits_enabled",
                model.edits_enabled.Value ? 1 : 0, CurrentUsername);
            return Ok(new { });
        }

        [HttpPut]
        [Route("api/user/updateDeleteRights")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateDeleteRights([FromBody] updateUserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "deletes_enabled",
                model.deletes_enabled.Value ? 1 : 0, CurrentUsername);
            return Ok(new { });
        }

        [HttpPut]
        [Route("api/user/updateAdminRights")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateAdminRights([FromBody] updateUserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "is_admin",
                model.is_Admin.Value ? 1 : 0, CurrentUsername);
            return Ok(new { });
        }

        [HttpPut]
        [Route("api/user/updateViewOnlyRights")]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> UpdateViewOnlyRights([FromBody] updateUserModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "is_ViewOnly",
                model.is_ViewOnly.Value ? 1 : 0, CurrentUsername);
            return Ok(new { });
        }

    }
}