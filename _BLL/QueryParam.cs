using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class QueryParam<T>
    {
        public QueryParam(int paginate = 1, int top = 10000)
        {
            Paginate = paginate;
            Top = top;
            Where = null;
            OrderBy =null;
            OrderByDescending = null;
        }
        public int Paginate { get; set; }
        public int Top { get; set; }    
        public Expression<Func<T,bool>> Where { get; set; }
        public Func<T,object> OrderBy { get; set; }
        public Func<T,object> OrderByDescending { get; set; }
    }
}
