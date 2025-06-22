using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BAL;
using DAL.DTOs;
//using BAL.DTOs;

namespace API.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/User")]
    public class UserController : ControllerBase
    {

       
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DTOUser), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = UserBusiness.GetUserById(id);
                return Ok(user);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult CreateUser([FromBody] DTOUser user)
        {
            try
            {
                var (success, userId, personId) = UserBusiness.CreateUser(user);

                if (success)
                {
                    return StatusCode(201, new
                    {
                        userId = userId,
                        personId = personId,
                        message = "User created successfully"
                    });
                }

                return StatusCode(500, new { message = "User creation failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult UpdateUser([FromBody] DTOUser user)
        {
            try
            {
                var result = UserBusiness.UpdateUser(user);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "User update failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var result = UserBusiness.DeleteUser(id);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "User deletion failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
