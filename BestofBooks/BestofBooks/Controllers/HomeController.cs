using BestofBooks.Models;
using BestofBooks.Models.ViewModels;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BestofBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepo _bookRepo;
        private readonly IUserRepo _userRepo;
        private readonly IAuditRepo _auditRepo;

        public HomeController(ILogger<HomeController> logger,
                              IBookRepo bookRepo,
                              IUserRepo userRepo,
                              IAuditRepo auditRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _auditRepo = auditRepo;
        }

        // ── Current user: read from cookie claims — zero DB cost ─────────────
        // User.FindFirstValue reads the encrypted cookie already in memory.
        // No database call, no session lookup.
        private string CurrentUsername =>
            User.FindFirstValue(ClaimTypes.Name) ?? "unauthorized";

        // Builds a lightweight UserModel from claims for views that need it.
        // Only hits the DB if the user is actually logged in.
        private async Task<UserModel?> GetLoggedInUserAsync()
        {
            if (!User.Identity?.IsAuthenticated ?? true) return null;

            var idClaim = User.FindFirstValue("BoBuser_id");
            if (!int.TryParse(idClaim, out var userId)) return null;

            return await _userRepo.getUserById(userId);
        }

        // ── INVENTORY LIST ────────────────────────────────────────────────────

        public async Task<IActionResult> InventoryList()
        {
            var books = await _bookRepo.GetInventoryList();
            var model = new InventoryListViewModel
            {
                invListBooks = books.Where(b => b.Quantity > 0).ToList(),
                LoggedInUser = await GetLoggedInUserAsync(),
                newBook = new BookModel()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdds")]
        public async Task<IActionResult> InventoryList(InventoryListViewModel model)
        {
            await _bookRepo.CreateBook(model.newBook, CurrentUsername);

            var books = await _bookRepo.GetInventoryList();
            model.invListBooks = books.Where(b => b.Quantity > 0).ToList();
            model.LoggedInUser = await GetLoggedInUserAsync();
            model.newBook = new BookModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireEdits")]
        public async Task<IActionResult> InventoryListUpdate(InventoryListViewModel model)
        {
            await _bookRepo.EditBook(model.editBook, CurrentUsername);

            var books = await _bookRepo.GetInventoryList();
            model.invListBooks = books.Where(b => b.Quantity > 0).ToList();
            model.LoggedInUser = await GetLoggedInUserAsync();
            model.newBook = new BookModel();
            return View("InventoryList", model);
        }

        // ── SEARCH ────────────────────────────────────────────────────────────

        public async Task<IActionResult> Search()
        {
            var model = new SearchViewModel
            {
                LoggedInUser = await GetLoggedInUserAsync(),
                Results = new List<BookModel>()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            var books = await _bookRepo.GetInventoryList();

            // Case-insensitive partial matching — "efren" now finds "Efren Reyes"
            var q = model.Query?.Trim() ?? string.Empty;

            model.Results = model.FilterType switch
            {
                "Genre" => books.Where(b => b.Genre
                                  .Contains(q, StringComparison.OrdinalIgnoreCase)).ToList(),
                "LastName" => books.Where(b => b.AuthorLast
                                  .Contains(q, StringComparison.OrdinalIgnoreCase)).ToList(),
                "FirstName" => books.Where(b => b.AuthorFirst
                                  .Contains(q, StringComparison.OrdinalIgnoreCase)).ToList(),
                "Title" => books.Where(b => b.Title
                                  .Contains(q, StringComparison.OrdinalIgnoreCase)).ToList(),
                _ => new List<BookModel>()
            };

            model.LoggedInUser = await GetLoggedInUserAsync();
            return View(model);
        }

        // ── REPORTS ───────────────────────────────────────────────────────────

        [Authorize(Policy = "RequireLogin")]
        public async Task<IActionResult> Reports()
        {
            var model = new BaseViewModel { LoggedInUser = await GetLoggedInUserAsync() };
            return View(model);
        }

        [Authorize(Policy = "RequireLogin")]
        public async Task<IActionResult> AvailableInventoryListReport()
        {
            var model = new AvailableReportViewModel
            {
                bookAuthors = await _bookRepo.getAuthors(),
                bookGenres = await _bookRepo.getGenres(),
                listBooks = new List<BookModel>(),
                bookFilters = new BookFilters(),
                LoggedInUser = await GetLoggedInUserAsync()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireLogin")]
        public async Task<IActionResult> AvailableInventoryListReport(AvailableReportViewModel model)
        {
            var all = await _bookRepo.GetSearchList();

            model.listBooks = all
                .Where(b => string.IsNullOrEmpty(model.bookFilters?.Genre)
                         || b.Genre.Equals(model.bookFilters.Genre, StringComparison.OrdinalIgnoreCase))
                .Where(b => string.IsNullOrEmpty(model.bookFilters?.Author)
                         || b.AuthorFullName.Contains(model.bookFilters.Author, StringComparison.OrdinalIgnoreCase))
                .Where(b => model.bookFilters?.Stock is null or "all"
                         || (model.bookFilters.Stock == "instock" && b.InStock)
                         || (model.bookFilters.Stock == "outofstock" && !b.InStock))
                .ToList();

            // Repopulate dropdowns but keep the user's filter selections intact
            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.LoggedInUser = await GetLoggedInUserAsync();
            return View(model);
        }

        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> ChangeHistoryReport()
        {
            var model = new ChangeHistoryReportViewModel
            {
                LoggedInUser = await GetLoggedInUserAsync(),
                DimUsernames = await _userRepo.getUserNames(),
                DimLastnames = await _userRepo.getUserLastNames(),
                Results = new List<AuditRecord>()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> ChangeHistoryReport(ChangeHistoryReportViewModel model)
        {
            var records = await _auditRepo.GetAuditRecords(
                model.UsernameFilter,
                model.LastnameFilter,
                model.StartDate,
                model.EndDate);

            model.DimUsernames = await _userRepo.getUserNames();
            model.DimLastnames = await _userRepo.getUserLastNames();
            model.LoggedInUser = await GetLoggedInUserAsync();
            model.Results = records;
            return View(model);
        }

        // ── ADMIN ─────────────────────────────────────────────────────────────

        [Authorize(Policy = "RequireAdmin")]
        public async Task<IActionResult> Admin()
        {
            var users = await _userRepo.getUsers();
            var model = new UserViewModel
            {
                LoggedInUser = await GetLoggedInUserAsync(),
                listUsers = users
            };
            return View(model);
        }

        // ── ACCOUNT CREATION ─────────────────────────────────────────────────

        public async Task<IActionResult> CreateAccount()
        {
            var model = new CreateAccountViewModel
            {
                LoggedInUser = await GetLoggedInUserAsync(),
                UserToCreate = new UserModel()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.LoggedInUser = await GetLoggedInUserAsync();
                return View(model);
            }

            model.UserToCreate.password = SecurityUtilities.HashPassword(model.UserToCreate.password);
            model.UserToCreate.is_ViewOnly = true;

            await _userRepo.createUser(model.UserToCreate, model.UserToCreate.username);

            _logger.LogInformation("New account created for {Username}.", model.UserToCreate.username);

            // Redirect after POST — prevents double-submit on browser refresh
            return RedirectToAction(nameof(InventoryList));
        }

        // ── AUTH ──────────────────────────────────────────────────────────────

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("User {Username} logged out.", CurrentUsername);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(InventoryList));
        }

        // ── MISC ──────────────────────────────────────────────────────────────

        public async Task<IActionResult> Privacy()
        {
            var model = new BaseViewModel { LoggedInUser = await GetLoggedInUserAsync() };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}