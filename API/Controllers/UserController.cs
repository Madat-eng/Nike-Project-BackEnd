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


        [HttpPost("SignUp")]
        [ProducesResponseType(typeof(DTOUserCreated), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult SignUp([FromBody] DTOUserSignUp user)
        {
            try
            {
                var createdUser = UserBusiness.CreateUser(user);
                return Ok(createdUser);
            }
            catch (ApplicationException ex) when (ex.Message.Contains("email"))
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("Login")]
        [ProducesResponseType(typeof(DTOUserLoginResult), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult Login([FromBody] DTOUserLogin user)
        {
            try
            {
                var loginResult = UserBusiness.Login(user);
                return Ok(loginResult);
            }
            catch (ApplicationException ex) when (ex.Message.Contains("Invalid email or password"))
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }




}
