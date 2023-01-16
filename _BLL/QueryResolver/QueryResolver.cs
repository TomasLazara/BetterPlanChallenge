using _BLL.UnitOfWork;
using _DAL;
using BetterPlanChallenge.Model;
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
        //se inyecta UNIT OF WORK para poder acceder a la instancia de base de datos alli alojada.
        private IUnitOfWork _unitOfWork;

        public QueryResolver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //se crea un diccionario donde su clave es la entidad a mapear y el valor es su instancia inyectando UNIT OF WORK
            _query = new Dictionary<string, IQueryResolver>
            {
                {typeof(Summary).Name, new SummaryQuery(unitOfWork)},
                {typeof(GoalDetails).Name, new GoalQuery(unitOfWork) }
            };
        }
        public async Task<IEnumerable<T>> Execute<T>(Dictionary<string, string> Stringparams)
        {        
            //Se ejecuta la instancia encontrada por su clave enviando los parametros a utilizar en el query
            return await _query[typeof(T).Name].Execute<T>(Stringparams);
        }
    }
}
