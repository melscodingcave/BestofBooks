using BestofBooks.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IBookRepo
    {
        Task<List<SelectListItem>> getAuthors();
        Task<List<BookModel>> GetAvailableInventoryList();
        Task<List<SelectListItem>> getGenres();
        Task<List<BookModel>> GetInventoryList();
        Task<List<BookModel>> GetSearchList();
        Task CreateBook(BookModel newBook, string modifiedBy);
        Task EditBook(BookModel newBook, string modifiedBy);
    }
}