using BetterPlanChallenge.Model;

namespace BetterPlanChallenge.DTOs
{
    public class GoalsDTO
    {
        public string Title { get; set; }
        public int Years { get; set; }
        public int Initialinvestment { get; set; }
        public int MonthlyContribution { get; set; }
        public int TargetAmount { get; set; }
        public DateTime? Created { get; set; }
    
        public static implicit operator GoalsDTO(Goal db)
        {
            var _db = db;
            var tis = new GoalsDTO();
            tis.Title = _db.Title;
            tis.Years = _db.Years;
            tis.Initialinvestment= _db.Initialinvestment;
            tis.TargetAmount = _db.Targetamount;          
            tis.Created = _db.Created;
            return tis;

        }
    }
}
