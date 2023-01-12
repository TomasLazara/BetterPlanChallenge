using _DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.QueryResolver
{
    public interface IQueryResolver
    {
        Task<IEnumerable<T>> Execute<T>(Dictionary<string,string> stringParams);
    }
}
