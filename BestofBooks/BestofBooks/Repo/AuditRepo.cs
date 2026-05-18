using BestofBooks.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BestofBooks.Repo
{
    public class AuditRepo : IAuditRepo
    {
        private readonly string _connString;

        public AuditRepo(IConfiguration config)
        {
            _connString = config.GetConnectionString("BestofBooks");
        }

        private IDbConnection Connect() => new SqlConnection(_connString);

        // ── UNFILTERED ────────────────────────────────────────────────────────

        public async Task<List<AuditRecord>> GetAuditRecords()
        {
            using var db = Connect();
            var records = await db.QueryAsync<AuditRecord>(
                "GetAuditRecords",
                commandType: CommandType.StoredProcedure);
            return records.ToList();
        }

        // ── FILTERED ──────────────────────────────────────────────────────────
        // Passes filter params to SQL rather than loading everything into memory.
        // NULL parameters are handled in the stored proc with IS NULL OR checks,
        // so unset filters are simply ignored by the query.

        public async Task<List<AuditRecord>> GetAuditRecords(
            string? usernameFilter,
            string? lastnameFilter,
            DateTime? startDate,
            DateTime? endDate)
        {
            using var db = Connect();
            var records = await db.QueryAsync<AuditRecord>(
                "GetAuditRecordsFiltered",
                new
                {
                    UsernameFilter = usernameFilter,
                    LastnameFilter = lastnameFilter,
                    StartDate = startDate,
                    EndDate = endDate
                },
                commandType: CommandType.StoredProcedure);
            return records.ToList();
        }
    }
}