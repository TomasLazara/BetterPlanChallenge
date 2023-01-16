using BetterPlanChallenge.Model;

namespace BetterPlanChallenge.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdvisorName { get; set; }
        public DateTime? CreationDate { get; set; }

        public static implicit operator UserDTO(User _db) 
        {
            var db = _db;
            var tis = new UserDTO();
            try
            {
                tis.Id = db.Id;
                tis.Name = $"{db.Firstname} {db.Surname}";
                if(db.Advisor !=null)
                {
                    tis.AdvisorName = $"{db.Advisor.Surname} {db.Advisor.Firstname}";
                }
                tis.CreationDate = db.Created;
                
                return tis;
            }
            catch (Exception ex)
            {

                throw;
            }            
        }
    }
}
