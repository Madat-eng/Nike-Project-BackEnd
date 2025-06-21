using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BAL;
using DAL.DTOs;
//using BAL.DTOs;

namespace API.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("GetUserByID/{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetUserByID(int userID)
        {
            DTOUser user = BAL.UserBusiness.GetUserByID(userID);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
