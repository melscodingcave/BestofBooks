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
    public class BookRepo : IBookRepo
    {
        private readonly string _connString;

        public BookRepo(IConfiguration config)
        {
            _connString = config.GetConnectionString("BestofBooks");
        }

        private IDbConnection Connect() => new SqlConnection(_connString);

        // ── INVENTORY ─────────────────────────────────────────────────────────

        public async Task<List<BookModel>> GetInventoryList()
        {
            using var db = Connect();
            var books = await db.QueryAsync<BookModel>(
                "GetInventoryList",
                commandType: CommandType.StoredProcedure);
            return books.ToList();
        }

        public async Task<List<BookModel>> GetSearchList()
        {
            using var db = Connect();
            var books = await db.QueryAsync<BookModel>(
                "BookSearch",
                commandType: CommandType.StoredProcedure);
            return books.ToList();
        }

        // ── CREATE / EDIT ─────────────────────────────────────────────────────

        public async Task CreateBook(BookModel newBook, string modifiedBy)
        {
            using var db = Connect();
            await db.ExecuteAsync("CreateNewBook", new
            {
                isbn = newBook.ISBN,
                title = newBook.Title,
                authorFirst = newBook.AuthorFirst,
                authorLast = newBook.AuthorLast,
                genre = newBook.Genre,
                location = newBook.Location,
                price = newBook.Price,
                quantity = newBook.Quantity,
                modifiedBy
            },
            commandType: CommandType.StoredProcedure);
        }

        public async Task EditBook(BookModel book, string modifiedBy)
        {
            using var db = Connect();
            await db.ExecuteAsync("EditBook", new
            {
                bookID = book.Id,
                isbn = book.ISBN,
                title = book.Title,
                authorFirst = book.AuthorFirst,
                authorLast = book.AuthorLast,
                genre = book.Genre,
                location = book.Location,
                price = book.Price,
                quantity = book.Quantity,
                modifiedBy
            },
            commandType: CommandType.StoredProcedure);
        }

        // ── DROPDOWN HELPERS ──────────────────────────────────────────────────

        public async Task<List<SelectListItem>> getAuthors()
        {
            using var db = Connect();
            var authors = await db.QueryAsync<Authors>(
                "SELECT * FROM dbo.Author ORDER BY author_lastname");
            return authors.Select(a => new SelectListItem
            {
                Text = $"{a.author_lastname}, {a.author_firstname}",
                Value = $"{a.author_lastname}, {a.author_firstname}"
            }).ToList();
        }

        public async Task<List<SelectListItem>> getGenres()
        {
            using var db = Connect();
            var genres = await db.QueryAsync<Genre>(
                "SELECT * FROM dbo.Genre ORDER BY genre_type");
            return genres.Select(g => new SelectListItem
            {
                Text = g.genre_type,
                Value = g.genre_type
            }).ToList();
        }
    }
}