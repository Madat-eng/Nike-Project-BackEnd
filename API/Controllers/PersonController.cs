//using DAL.DTOs;
//using Microsoft.AspNetCore.Mvc;
//using BAL;

//namespace API.Controllers.v1
//{
//    [ApiController]
//    [ApiVersion("1.0")]
//    [Route("api/v{version:apiVersion}/Person")]
//    public class PersonController : ControllerBase
//    {
//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(DTOPerson), 200)]
//        [ProducesResponseType(typeof(string), 404)]
//        [ProducesResponseType(typeof(string), 500)]
//        public IActionResult GetPersonById(int id)
//        {
//            try
//            {
//                var person = PersonBusiness.GetPersonById(id);
//                return Ok(person);
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, new { message = ex.Message });
//            }
//        }

//        [HttpPost]
//        [ProducesResponseType(201)]
//        [ProducesResponseType(typeof(string), 500)]
//        public IActionResult CreatePerson([FromBody] DTOPerson person)
//        {
//            try
//            {
//                var result = PersonBusiness.CreatePerson(person);
//                if (result)
//                    return StatusCode(201);
//                return StatusCode(500, new { message = "Person creation failed." });
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, new { message = ex.Message });
//            }
//        }

//        [HttpPut]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(typeof(string), 500)]
//        public IActionResult UpdatePerson([FromBody] DTOPerson person)
//        {
//            try
//            {
//                var result = PersonBusiness.UpdatePerson(person);
//                if (result)
//                    return Ok();
//                return StatusCode(500, new { message = "Person update failed." });
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, new { message = ex.Message });
//            }
//        }

//        [HttpDelete("{id}")]
//        [ProducesResponseType(200)]
//        [ProducesResponseType(typeof(string), 500)]
//        public IActionResult DeletePerson(int id)
//        {
//            try
//            {
//                var result = PersonBusiness.DeletePerson(id);
//                if (result)
//                    return Ok();
//                return StatusCode(500, new { message = "Person deletion failed." });
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, new { message = ex.Message });
//            }
//        }
//    }
//}
