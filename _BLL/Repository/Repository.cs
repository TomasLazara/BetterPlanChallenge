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
        public async Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindById(int Id)
        {
            try
            {
                var obj = DbSet.FirstOrDefault(x => x.Id == Id);                
                return obj;               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<T> FindByName(string Name) { 
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> FindForParam(QueryParam<T> queryParam)
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

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
