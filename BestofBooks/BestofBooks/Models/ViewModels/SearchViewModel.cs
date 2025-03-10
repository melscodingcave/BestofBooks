using System;
using System.Collections.Generic;

namespace BestofBooks.Models.ViewModels
{
	public class SearchViewModel : BaseViewModel
	{
		public string FilterType { get; set; }
		public string Query { get; set; }
		public List<BookModel> Results { get; set; }
	}
}

