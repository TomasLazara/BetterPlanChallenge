using _DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL
{
    public class Order<T> where T : EntityMaster
    {
        public Order()
        {

        }
        public Order(Func<T,object> orderBy, bool isAscending)
        {
            OrderBy = orderBy;
            IsAscending = isAscending;
        }
        public Func<T,object> OrderBy { get; set; }
        public bool IsAscending { get; set; }

        private Order<T> GetOrderBy(QueryParam<T> queryParam)
        {
            if(queryParam.OrderBy == null && queryParam.OrderByDescending == null)
            {
                return new Order<T>(x=> x.Id, true);
            }

            return (queryParam.OrderBy != null) ? new Order<T>(queryParam.OrderBy,true) :
                new Order<T>(queryParam.OrderByDescending, false);
        }
    }
}
