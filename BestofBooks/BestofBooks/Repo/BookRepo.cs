using BestofBooks.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BestofBooks.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly IConfiguration _config;

        public BookRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<BookModel>> GetInventoryList()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<BookModel> books = (await dbConnection.QueryAsync<BookModel>("GetInventoryList", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return books;
        }

        public async Task<List<SelectListItem>> getAuthors()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<Authors> authors = (await dbConnection.QueryAsync<Authors>("SELECT * FROM dbo.Author")).ToList();

            return AuthorsToSelectListItems(authors);
        }

        private List<SelectListItem> AuthorsToSelectListItems(IEnumerable<Authors> authors)
        {
            return authors
                .Select(l => new SelectListItem
                {
                    Text = $"{l.author_lastname}, {l.author_firstname}",
                    Value = $"{l.author_lastname}, {l.author_firstname}"
                })
                .ToList();
        }

        public async Task<List<SelectListItem>> getGenres()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<Genre> genres = (await dbConnection.QueryAsync<Genre>("SELECT * FROM dbo.Genre")).ToList();

            return GenresToSelectListItems(genres);
        }

        private List<SelectListItem> GenresToSelectListItems(IEnumerable<Genre> genres)
        {
            return genres
                .Select(l => new SelectListItem
                {
                    Text = l.genre_type,
                    Value = l.genre_type
                })
                .ToList();
        }

        public async Task<List<BookModel>> GetAvailableInventoryList()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<BookModel> books = (await dbConnection.QueryAsync<BookModel>("GetAvailableInventory", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return books;
        }

        public async Task<List<BookModel>> GetSearchList()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<BookModel> books = (await dbConnection.QueryAsync<BookModel>("BookSearch", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return books;
        }

        public async Task CreateBook(BookModel newBook, string modifiedBy)
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            object[] parameters =
            {
                new {
                    isbn = newBook.ISBN,
                    title = newBook.Title,
                    authorFirst = newBook.AuthorFirst,
                    authorLast = newBook.AuthorLast,
                    genre = newBook.Genre,
                    location = newBook.Location,
                    price = newBook.Price,
                    quantity = newBook.Quantity,
                    modifiedBy = modifiedBy
                }
            };

            await dbConnection.ExecuteAsync("CreateNewBook", param: parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task EditBook(BookModel book, string modifiedBy)
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            object[] parameters =
            {
                new {
                    bookID = book.Id,
                    isbn = book.ISBN,
                    title = book.Title,
                    authorFirst = book.AuthorFirst,
                    authorLast = book.AuthorLast,
                    genre = book.Genre,
                    location = book.Location,
                    price = book.Price,
                    quantity = book.Quantity,
                    modifiedBy = modifiedBy
                }
            };

            await dbConnection.ExecuteAsync("EditBook", param: parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
