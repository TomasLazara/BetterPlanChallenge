using BetterPlanChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.Repository
{
    public class DBOperationsRepository : IDBORepository
    {
        private DbContext _db;
        public DBOperationsRepository(DbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Tout>> ResolveQuery<Tout>(string query) 
        {
            try
            {
                var databaseResult = _db.Database.SqlQueryRaw<Tout>(query);                               
                return databaseResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
