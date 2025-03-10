using BestofBooks.Models;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BestofBooks.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IBookRepo _bookRepo;

        public BookController(ILogger<UserController> logger, IBookRepo bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
        }

        [HttpGet]
        [Route("api/book/getBookSearchList")]
        public async Task<IActionResult> getBookSearchList([FromBody] BookModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _bookRepo.GetSearchList();
            return Ok(new { });
        }

        [HttpGet]
        [Route("api/book/getAvailInvList")]
        public async Task<IActionResult> getAvailInvList([FromBody] BookModel model)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);
            await _bookRepo.GetAvailableInventoryList();
            return Ok(new { });
        }
    }
}
