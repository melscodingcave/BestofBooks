using BestofBooks.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public interface IAuditRepo
    {
        /// <summary>
        /// Returns all audit records — used when no filters are applied.
        /// </summary>
        Task<List<AuditRecord>> GetAuditRecords();

        /// <summary>
        /// Returns filtered audit records. Null parameters are treated as "no filter".
        /// Filtering happens in SQL rather than loading all records into memory first.
        /// </summary>
        Task<List<AuditRecord>> GetAuditRecords(
            string? usernameFilter,
            string? lastnameFilter,
            DateTime? startDate,
            DateTime? endDate);
    }
}