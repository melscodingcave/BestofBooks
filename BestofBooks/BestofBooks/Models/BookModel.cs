using System;
namespace BestofBooks.Models
{
	public class BookModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string AuthorFirst { get; set; }
		public string AuthorLast { get; set; }
		public string Genre { get; set; }
		public bool InStock { get; set; }
		public string ISBN { get; set; }
		public string Location { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string AuthorFullName { get { return AuthorLast + ", " + AuthorFirst; } }
	}
}

