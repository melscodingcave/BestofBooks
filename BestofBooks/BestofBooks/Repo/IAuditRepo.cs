using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestofBooks.Models;

namespace BestofBooks.Repo
{
	public interface IAuditRepo
	{
		public Task<List<AuditRecord> >GetAuditRecords();
	}
}

