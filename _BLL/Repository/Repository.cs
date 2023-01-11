using _DAL;
using BetterPlanChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityMaster
    {
        private DbContext _db;
        private DbSet<T> DbSet;
        public Repository(DbContext ctx)
        {
            _db= ctx;
            DbSet = _db.Set<T>();

        }
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public T FindByName(string Name) { 
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindForParam(QueryParam<T> queryParam)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
              var lst =  await DbSet.ToListAsync<T>();
              return lst;
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
