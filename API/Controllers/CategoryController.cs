using Microsoft.AspNetCore.Mvc;
using BAL;
using DAL.DTOs;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Category")]
    public class CategoryController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = CategoryBusiness.GetCategoryById(id);
                return Ok(category);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = CategoryBusiness.GetAllCategories();
                return Ok(categories);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] DTOCategory category)
        {
            try
            {
                var (success, id) = CategoryBusiness.CreateCategory(category);
                if (success)
                    return StatusCode(201, new { CategoryID = id });
                return StatusCode(500, new { message = "Creation failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] DTOCategory category)
        {
            try
            {
                var result = CategoryBusiness.UpdateCategory(category);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "Update failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                var result = CategoryBusiness.DeleteCategory(id);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "Deletion failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
