using _BLL.UnitOfWork;
using _DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BLL.QueryResolver
{
    public class SummaryQuery : IQueryResolver
    {
        private readonly IUnitOfWork _unitOfWork;
        private string baseQuery; 
        //LEER: La resolucion aqui planteada me parece ineficiente, lo que hubiera hecho y que es intuitivo
        //es mapear el query al tipo SUMMARY o GOALDETAIL.Pero no pude sortear la excepcion lanzada para ello.
        //probe el mismo codigo en SQL SERVER y me funciono, otra forma pudiera haber sido crear en la base de datos
        //una vista o un SP. Frente la imposibilidad segmente de la siguiente manera.
        public SummaryQuery(IUnitOfWork unitOfWork)
        {
              _unitOfWork= unitOfWork;
                //aqui la base del query con sus joins
               baseQuery = @"                
                from goaltransactionfunding gtf 
                 inner join fundingsharevalue fsv 
 	                ON gtf.fundingid = fsv.fundingid
                 inner join goaltransaction gt 
 	                ON gt.id = gtf.goalid 
                 inner join goal g
 	                ON g.id  = gt.goalid 
                 inner join funding f 
 	                on f.id = gtf.fundingid
                 inner join currencyindicator cig 
 	                on cig.destinationcurrencyid = g.currencyid 
 	                and cig.""date"" = gtf.""date"" 
                 inner join  currencyindicator cif 
 	                on cif.destinationcurrencyid = f.currencyid 
 	                and cif.""date"" = gtf.""date"" 
                 where gtf.ownerid = @id
            "; 
        }
        public async Task<IEnumerable<T>> Execute<T>(Dictionary<string, string> stringParams) 
        {
            stringParams.TryGetValue("UserId", out var id);
            if(id== null)
            {
                throw new Exception("The paramater User Id is required for execute the summary operation");
            }
            List<Summary> summaries = new List<Summary>();
            summaries.Add(
                new Summary() { Balance =  await getBalanceAsync(id), 
                    CurrentlyContributions = await CurrentlyContributionsAsync(id)
                });
            return (IEnumerable<T>)summaries;

        }
        private async Task<double> getBalanceAsync(string id)
        {
            var query = @"select 
                Sum((gtf.quotas * fsv.value * cig.value)) as balance               
             ";
            query += baseQuery;

            //Se reemplazan los parametros.
            query = query.Replace("@id", id);

            //enviamos a la instancia de base de datos el query a resolver.
            var dbEntity =  await _unitOfWork.Dbo.ResolveQuery<double?>(query);
            var result = !dbEntity.FirstOrDefault().HasValue ? 0.0 : dbEntity.FirstOrDefault();
            return (double)result;
        }
        private async Task<double> CurrentlyContributionsAsync(string id)
        {
            var query = @"
                select 
                    Sum(gt.amount) as contributions                
              ";
            query += baseQuery;
            //Se reemplazan los parametros.

            query = query.Replace("@id", id);
            //enviamos a la instancia de base de datos el query a resolver.

            var dbEntity = await _unitOfWork.Dbo.ResolveQuery<double?>(query);
            var result = !dbEntity.FirstOrDefault().HasValue ? 0.0 : dbEntity.FirstOrDefault();
            return (double)result;
        }
    }
}
