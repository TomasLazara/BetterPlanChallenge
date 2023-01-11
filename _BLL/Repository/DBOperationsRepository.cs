using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                var databaseList = _db.Database.SqlQueryRaw<Tout>(query);
                var lst = databaseList.ToListAsync();
                return await lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
