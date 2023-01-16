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
    internal class GoalQuery : IQueryResolver
    {
        private readonly IUnitOfWork _unitOfWork;
        private string _queryBase;
        //LEER: La resolucion aqui planteada me parece ineficiente, lo que hubiera hecho y que es intuitivo
        //es mapear el query al tipo SUMMARY o GOALDETAIL.Pero no pude sortear la excepcion lanzada para ello.
        //probe el mismo codigo en SQL SERVER y me funciono, otra forma pudiera haber sido crear en la base de datos
        //una vista o un SP. Frente la imposibilidad segmente de la siguiente manera.
        public GoalQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _queryBase = @"from goal g 	
            inner join goaltransaction gtbuy 
	            on gtbuy.goalid  = g.id
            inner join goaltransaction gtsale
	            on gtsale.goalid  = g.id
            inner join goaltransactionfunding gtf 
	            on gtf.goalid  = g.id 
            inner join fundingsharevalue fsv 
                ON gtf.fundingid = fsv.fundingid
            inner join currencyindicator cig 
             on cig.destinationcurrencyid = g.currencyid
             and cig.""date"" = gtf.""date"" 
            where gtsale.""type""='sale'
            and   gtbuy .""type""='buy'
            and g.userid =@userId 
            and g.id = @id
            group by g.id;";        
        }
        public async Task<IEnumerable<T>> Execute<T>(Dictionary<string, string> stringParams)
        {
            stringParams.TryGetValue("GoalId", out var id);
            stringParams.TryGetValue("UserId", out var Userid);

            if (id == null)
            {
                throw new Exception("The paramater User GoalId is required for execute the summary operation");
            }
            if (Userid == null)
            {
                throw new Exception("The paramater User UserId is required for execute the summary operation");
            }
 	         
            var goalBase = await getGoalBase(id);
            var percentage = await GetPercentage(id,Userid);
            var withdrawal = await GetWithdrawal(id,Userid);
            var contributions = await GetContributions(id, Userid);
            List<GoalDetails> goals = new List<GoalDetails>();
            var goalDetail = new GoalDetails()
            {
                Contributions = contributions,
                Withdrawal = withdrawal,
                Created = goalBase.Created,
                Initialinvestment = goalBase.Initialinvestment,
                MonthlyContribution = goalBase.Monthlycontribution,
                percentageComplete = percentage,
                TargetAmount = goalBase.Targetamount,
                Title = goalBase.Title,
                Years = goalBase.Years,
            };
            goals.Add(goalDetail);
            return (IEnumerable<T>)goals;
        }

        private async Task<Goal> getGoalBase(string id) 
        {
            return await _unitOfWork.Goals.FindById(Convert.ToInt32(id));
        }
        private async Task<double> GetWithdrawal(string id, string UserId) {
            var query = @"  select distinct     ";
            query += "sum(gtsale.amount)as withdrawal    ";
            query += _queryBase;
            query = query.Replace("@id", id);
            query = query.Replace("@userId", UserId);
            var dbEntity = await _unitOfWork.Dbo.ResolveQuery<double?>(query);
            var result = !dbEntity.FirstOrDefault().HasValue ? 0.0 : dbEntity.FirstOrDefault();
            return (double)result;
        }
        private async Task<double> GetContributions(string id, string UserId) {
            var query = @"  select distinct     ";
            query += " sum(gtbuy.amount) as contributions  ";
            query += _queryBase;
            query = query.Replace("@id", id);
            query = query.Replace("@userId", UserId);
            var dbEntity = await _unitOfWork.Dbo.ResolveQuery<double?>(query);
            var result = !dbEntity.FirstOrDefault().HasValue ? 0.0 : dbEntity.FirstOrDefault();
            return (double)result;
        }
        private async Task<double> GetPercentage(string id, string UserId) {
            var query = @"  select distinct     ";
            query += "(Sum((gtf.quotas * fsv.value * cig.value)) * (g.targetamount/100))as percentageComplete  ";
            query += _queryBase;
            query = query.Replace("@id", id);
            query = query.Replace("@userId", UserId);


            var dbEntity = await _unitOfWork.Dbo.ResolveQuery<double?>(query);
            var result = !dbEntity.FirstOrDefault().HasValue ? 0.0 : dbEntity.FirstOrDefault();
            return (double)result;
        }

    }
}
