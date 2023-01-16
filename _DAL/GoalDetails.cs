using BetterPlanChallenge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DAL
{
    public class GoalDetails 
    {
        public string Title { get; set; }
        public int Years { get; set; }
        public int Initialinvestment { get; set; }
        public int MonthlyContribution { get; set; }
        public int TargetAmount { get; set; }
        public DateTime? Created { get; set; }
        public double? Contributions { get; set; }
        public double? Withdrawal { get; set; }
        public double? percentageComplete { get; set; }
    }
}
