using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BestofBooks.Models;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BestofBooks.Repo
{
	public class AuditRepo : IAuditRepo
	{
        private readonly IConfiguration _config;

        public AuditRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<AuditRecord>> GetAuditRecords()
        {
            string connString = _config.GetConnectionString("BestofBooks");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<AuditRecord> records = (await dbConnection.QueryAsync<AuditRecord>("GetAuditRecords", new { }, commandType: CommandType.StoredProcedure)).ToList();

            return records;
        }
    }
}

