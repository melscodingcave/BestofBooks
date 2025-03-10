using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BestofBooks.Models.ViewModels
{
	public class ChangeHistoryReportViewModel : BaseViewModel
	{
		public List<SelectListItem> DimUsernames { get; set; }
		public List<SelectListItem> DimLastnames { get; set; }

		public string UsernameFilter { get; set; }
		public string LastnameFilter { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public List<AuditRecord> Results { get; set; }
	}
}

