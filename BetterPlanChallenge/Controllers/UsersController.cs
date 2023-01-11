using _BLL.UnitOfWork;
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
        public UsersController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork= UnitOfWork;
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
        #endregion
    }
}
