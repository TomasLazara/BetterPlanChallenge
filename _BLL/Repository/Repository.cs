using _DAL;
using BetterPlanChallenge.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _db = ctx;
            DbSet = _db.Set<T>();

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

        public async Task<IEnumerable<T>> FindForParam(QueryParam<T> queryParam)
        {
            var orderByClass = GetOrderBy(queryParam);
            Expression<Func<T, bool>> whereTrue = x => true;
            var where = (queryParam.Where == null) ? whereTrue : queryParam.Where;

            if (orderByClass.IsAscending)
            {
                return DbSet.Where(where).OrderBy(orderByClass.OrderBy)
                    .Skip((queryParam.Paginate - 1) * queryParam.Top)
                    .Take(queryParam.Top).ToList();
            }
            else
            {
                return DbSet.Where(where).Where(where).OrderByDescending(orderByClass.OrderBy)
                    .Skip((queryParam.Paginate - 1) * queryParam.Top)
                    .Take(queryParam.Top).ToList();
            }
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var lst = await DbSet.ToListAsync<T>();
                return lst;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        private Order<T> GetOrderBy(QueryParam<T> queryParam)
        {
            if (queryParam.OrderBy == null && queryParam.OrderByDescending == null)
            {
                return new Order<T>(x => x.Id, true);
            }

            return (queryParam.OrderBy != null)
                ? new Order<T>(queryParam.OrderBy, true) :
                new Order<T>(queryParam.OrderByDescending, false);

        }
    }

}
