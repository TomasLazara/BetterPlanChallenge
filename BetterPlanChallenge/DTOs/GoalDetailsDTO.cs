using _DAL;

namespace BetterPlanChallenge.DTOs
{
    public class GoalDetailsDTO : GoalsDTO
    {
        public double? Contributions { get; set; }
        public double? Withdrawal { get; set; }
        public double? percentageComplete{ get; set; }
        public static implicit operator GoalDetailsDTO(GoalDetails _db) {
            var dto = new GoalDetailsDTO();
            var db = _db;
            dto.Contributions = db.Contributions;
            dto.MonthlyContribution = db.MonthlyContribution;
            dto.Withdrawal = db.Withdrawal; 
            dto.Years = db.Years;
            dto.Initialinvestment = db.Initialinvestment;
            dto.Created = db.Created;
            dto.percentageComplete = db.TargetAmount;
            dto.TargetAmount = db.TargetAmount; 
            dto.Title = db.Title;
            return dto;        
        }
    }
}
