using System;
namespace BestofBooks.Models
{
	public class AuditRecord
	{
        public string TableName { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedLast { get; set; }
        public DateTime Modified { get; set; }
        public string Action { get; set; }
    }
}

