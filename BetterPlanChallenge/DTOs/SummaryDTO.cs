using _BLL;
using _DAL;

namespace BetterPlanChallenge.DTOs
{
    public class SummaryDTO
    {
        public double? Balance { get; set; }
        public double? CurrentlyContributions { get; set; }
        public static implicit operator SummaryDTO(Summary db) 
        {
            var tis = new SummaryDTO();
            tis.CurrentlyContributions = db.CurrentlyContributions;
            tis.Balance = db.Balance;  
            return tis;
        }
    }
}
