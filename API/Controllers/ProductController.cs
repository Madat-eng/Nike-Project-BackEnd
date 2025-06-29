using Microsoft.AspNetCore.Mvc;
using BAL;
using DAL.DTOs;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Product")]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DTOProduct), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = ProductBusiness.GetProductById(id);
                return Ok(product);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult CreateProduct([FromBody] DTOProduct product)
        {
            try
            {
                var (success, productId) = ProductBusiness.CreateProduct(product);
                if (success)
                    return StatusCode(201, new { ProductID = productId });
                return StatusCode(500, new { message = "Product creation failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult UpdateProduct([FromBody] DTOProduct product)
        {
            try
            {
                var result = ProductBusiness.UpdateProduct(product);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "Product update failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var result = ProductBusiness.DeleteProduct(id);
                if (result)
                    return Ok();
                return StatusCode(500, new { message = "Product deletion failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(List<DTOProduct>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = ProductBusiness.GetAllProducts();
                return Ok(products);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("Random/{count}")]
        [ProducesResponseType(typeof(List<DTOProduct>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetRandomProducts(int count)
        {
            try
            {
                var products = ProductBusiness.GetRandomProducts(count);
                return Ok(products);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("ByCategory/{categoryName}")]
        [ProducesResponseType(typeof(List<DTOProduct>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetAllProductsByCategory(string categoryName)
        {
            try
            {
                var products = ProductBusiness.GetAllProductsByCategory(categoryName);
                return Ok(products);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
