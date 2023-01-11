using _DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.Repository
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
        IEnumerable<T> FindForParam(QueryParam<T> queryParam);
    }
}
