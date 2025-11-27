using BestofBooks.Models;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
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
        [HttpPut]
        [Route("api/user/updateAddRights")]
        public async Task<IActionResult> updateAddRights([FromBody]updateUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "adds_enabled", model.adds_enabled.Value? 1 : 0, loggedInUser.username ?? "unauthorized");
            return Ok(new { });
        }
        [HttpPut]
        [Route("api/user/updateEditRights")]
        public async Task<IActionResult> updateEditRights([FromBody] updateUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "edits_enabled", model.edits_enabled.Value ? 1 : 0, loggedInUser.username ?? "unauthorized");
            return Ok(new { });
        }
        [HttpPut]
        [Route("api/user/updateDeleteRights")]
        public async Task<IActionResult> updateDeleteRights([FromBody] updateUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "deletes_enabled", model.deletes_enabled.Value ? 1 : 0, loggedInUser.username ?? "unauthorized");
            return Ok(new { });
        }
        [HttpPut]
        [Route("api/user/updateAdminRights")]
        public async Task<IActionResult> updateAdminRights([FromBody] updateUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "is_admin", model.is_Admin.Value ? 1 : 0, loggedInUser.username ?? "unauthorized");
            return Ok(new { });
        }
        [HttpPut]
        [Route("api/user/updateViewOnlyRights")]
        public async Task<IActionResult> updateViewOnlyRights([FromBody] updateUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.updateUserRights(model.BoBuser_id, "is_ViewOnly", model.is_ViewOnly.Value ? 1 : 0, loggedInUser.username ?? "unauthorized");
            return Ok(new { });
        }
        [HttpPost]
        [Route("api/user/logIn")]
        public async Task<IActionResult> logInUser([FromBody] LogInUserModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            bool userLoggedIn = await _userRepo.loginUser(model.Username, model.Password, this.HttpContext);
            if (userLoggedIn)
            {
                return Ok(new { });
            }
            else
            {
                return Unauthorized("Login failed.");
            }
        }

        [HttpGet]
        [Route("api/book/getChgHistRpt")]
        public async Task<IActionResult> getChgHistRpt([FromBody] BookModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _userRepo.getChangeHistory();
            return Ok(new { });
        }

        private UserModel loggedInUser => _userRepo.getUsers().Result.FirstOrDefault(u => u.BoBuser_id == this.HttpContext.Session.GetInt32("_loggedInUser"));
    }
}
