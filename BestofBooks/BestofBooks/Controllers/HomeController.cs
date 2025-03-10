using BestofBooks.Models;
using BestofBooks.Models.ViewModels;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BestofBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepo _bookRepo;
        private readonly IUserRepo _userRepo;
        private readonly IAuditRepo _auditRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepo bookRepo, IUserRepo userRepo, IAuditRepo auditRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
            _auditRepo = auditRepo;
        }

        public async Task<IActionResult> InventoryList()
        {
            List<BookModel> books = await _bookRepo.GetInventoryList();
            books = books.Where(b => b.Quantity > 0).ToList();
            var model = new InventoryListViewModel
            {
                invListBooks = books,
                LoggedInUser = loggedInUser,
                newBook = new BookModel()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InventoryList(InventoryListViewModel model)
        {
            await _bookRepo.CreateBook(model.newBook, loggedInUser.username);

            List<BookModel> books = await _bookRepo.GetInventoryList();
            books = books.Where(b => b.Quantity > 0).ToList();
            model.invListBooks = books;
            model.LoggedInUser = loggedInUser;
            model.newBook = new BookModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InventoryListUpdate(InventoryListViewModel model)
        {
            await _bookRepo.EditBook(model.editBook, loggedInUser.username);

            List<BookModel> books = await _bookRepo.GetInventoryList();
            books = books.Where(b => b.Quantity > 0).ToList();
            model.invListBooks = books;
            model.LoggedInUser = loggedInUser;
            model.newBook = new BookModel();
            return View("InventoryList", model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel { LoggedInUser = loggedInUser };
            return View(model);
        }

        public IActionResult Search()
        {
            var model = new SearchViewModel { LoggedInUser = loggedInUser, Results = new List<BookModel>()};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            var books = await _bookRepo.GetInventoryList();
            switch (model.FilterType)
            {
                case "Genre":
                    books = books.Where(b => b.Genre == model.Query).ToList();
                    break;
                case "LastName":
                    books = books.Where(b => b.AuthorLast == model.Query).ToList();
                    break;
                case "FirstName":
                    books = books.Where(b => b.AuthorFirst == model.Query).ToList();
                    break;
                case "Title":
                    books = books.Where(b => b.Title == model.Query).ToList();
                    break;
                default:
                    books = new List<BookModel>();
                    break;
            }

            model.Results = books;
            model.LoggedInUser = loggedInUser;
            return View(model);
        }

        public IActionResult Reports()
        {
            var model = new BaseViewModel { LoggedInUser = loggedInUser };
            return View(model);
        }

        public IActionResult CreateAccount()
        {
            var model = new CreateAccountViewModel { LoggedInUser = loggedInUser, UserToCreate = new UserModel() };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(CreateAccountViewModel model)
        {
            model.UserToCreate.password = SecurityUtilities.HashPassword(model.UserToCreate.password);
            model.UserToCreate.is_ViewOnly = true;
            _userRepo.createUser(model.UserToCreate, model.UserToCreate.username);
            var emptyModel = new CreateAccountViewModel { LoggedInUser = loggedInUser, UserToCreate = new UserModel() };
            return View(emptyModel);
        }

        public async Task<IActionResult> Admin()
        {
            List<UserModel> admins = await _userRepo.getUsers();
            var model = new UserViewModel { LoggedInUser = loggedInUser, listUsers = admins };
            return View(model);
        }

        public async Task<IActionResult> AvailableInventoryListReport()
        {
            var model = new AvailableReportViewModel();
            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.listBooks = new List<BookModel>();
            model.bookFilters = new BookFilters();
            model.LoggedInUser = loggedInUser;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AvailableInventoryListReport(AvailableReportViewModel model)
        {
            var filteredList = await _bookRepo.GetSearchList();
            model.listBooks = filteredList
                .Where(b => model.bookFilters == null || model.bookFilters.Genre == null || b.Genre == model.bookFilters.Genre)
                .Where(b => model.bookFilters == null || model.bookFilters.Author == null || b.AuthorFullName == model.bookFilters.Author)
                .Where(b => model.bookFilters == null || model.bookFilters.Stock == null || model.bookFilters.Stock == "all" || (model.bookFilters.Stock == "instock" && b.InStock) || (model.bookFilters.Stock == "outofstock" && !b.InStock))
                .ToList();

            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.LoggedInUser = loggedInUser;
            model.bookFilters = new BookFilters();
            return View(model);
        }

        public async Task<IActionResult> ChangeHistoryReport()
        {
            var model = new ChangeHistoryReportViewModel { LoggedInUser = loggedInUser };
            model.DimUsernames = await _userRepo.getUserNames();
            model.DimLastnames = await _userRepo.getUserLastNames();
            model.Results = new List<AuditRecord>();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeHistoryReport(ChangeHistoryReportViewModel model)
        {
            model.DimUsernames = await _userRepo.getUserNames();
            model.DimLastnames = await _userRepo.getUserLastNames();

            var records = await _auditRepo.GetAuditRecords();

            if (!string.IsNullOrEmpty(model.UsernameFilter))
                records = records.Where(a => a.ModifiedBy == model.UsernameFilter).ToList();
            if (!string.IsNullOrEmpty(model.LastnameFilter))
                records = records.Where(a => a.ModifiedLast == model.LastnameFilter).ToList();
            if (model.StartDate != DateTime.MinValue)
                records = records.Where(a => a.Modified >= model.StartDate).ToList();
            if (model.EndDate != DateTime.MinValue)
                records = records.Where(a => a.Modified <= model.EndDate.Date.AddDays(1).AddMinutes(-1)).ToList();

            model.Results = records;
            model.LoggedInUser = loggedInUser;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Logout()
        {
            this.HttpContext.Session.SetInt32("_loggedInUser", 0);
            return RedirectToAction("InventoryList");
        }

        private bool isUserLoggedIn => this.HttpContext.Session.GetInt32("_loggedInUser") != 0;
        private UserModel loggedInUser => _userRepo.getUsers().Result.FirstOrDefault(u => u.BoBuser_id == this.HttpContext.Session.GetInt32("_loggedInUser"));
    }
}
