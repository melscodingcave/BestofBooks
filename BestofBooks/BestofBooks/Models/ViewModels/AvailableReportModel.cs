using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BestofBooks.Models.ViewModels
{
    public class AvailableReportViewModel : BaseViewModel
    {
        public List<BookModel> listBooks { get; set; }
        public BookFilters bookFilters { get; set; }
        public List<SelectListItem> bookAuthors { get; set; }
        public List<SelectListItem> bookGenres { get; set; }
    }

    public class BookFilters
    {
        public string Genre { get; set; }
        public string Author { get; set; }
        public string Stock { get; set; }
    }
}
