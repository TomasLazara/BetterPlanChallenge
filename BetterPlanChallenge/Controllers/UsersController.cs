using _BLL;
using _BLL.QueryResolver;
using _BLL.UnitOfWork;
using _DAL;
using BetterPlanChallenge.DTOs;
using BetterPlanChallenge.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterPlanChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUnitOfWork _UnitOfWork;
        private IQueryResolver _queryResolver; 
        public UsersController(IUnitOfWork UnitOfWork, IQueryResolver queryResolver)
        {
            _UnitOfWork= UnitOfWork;
            _queryResolver= queryResolver;
        }

        #region public methods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            try
            {
                var usersDB = await _UnitOfWork.Users.GetAll();
                if (usersDB == null)
                {
                    return NoContent();
                }
                var usersDto = usersDB.Select(x =>
                {
                    var y = new UserDTO();
                    y = x;
                    return y;
                });

                return Ok(usersDto);

            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            try
            {
                var usersDB = await _UnitOfWork.Users.FindById(id);
                if(usersDB == null)
                {
                    return NoContent();
                }
                var usersDto = (UserDTO)usersDB;                               
                return Ok(usersDto);

            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}/summary")]
        public async Task<ActionResult<SummaryDTO>> GetSummaryForUser(int? id)
        {
            if (!id.HasValue)
            {
                return BadRequest("The paramater User Id is required for execute the summary operation");
            }
            try
            {
                var param = new Dictionary<string, string>();
                param.Add("UserId", id.ToString());
                var Summarydb = await _queryResolver.Execute<Summary>(param);
                return Ok((SummaryDTO)Summarydb.FirstOrDefault());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }           

        }

        
        #endregion
    }
}
