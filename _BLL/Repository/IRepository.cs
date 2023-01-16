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
        Task<T> FindById(int Id);
        Task<IEnumerable<T>> FindForParam(QueryParam<T> queryParam);
    }
}
