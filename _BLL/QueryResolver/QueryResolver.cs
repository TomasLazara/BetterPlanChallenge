using _BLL.UnitOfWork;
using _DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.QueryResolver
{
    public class QueryResolver : IQueryResolver
    {
        private readonly Dictionary<string, IQueryResolver> _query;
        private IUnitOfWork _unitOfWork;

        public QueryResolver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _query = new Dictionary<string, IQueryResolver>
            {
                {typeof(Summary).Name, new SummaryQuery(unitOfWork)}
            };
        }
        public async Task<IEnumerable<T>> Execute<T>(Dictionary<string, string> Stringparams)
        {        
            return await _query[typeof(T).Name].Execute<T>(Stringparams);
        }
    }
}
