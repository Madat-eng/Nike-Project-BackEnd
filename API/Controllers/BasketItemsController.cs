using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using BAL;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/BasketItems")]
    public class BasketItemsController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DTOBasketItems), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetBasketItemByID(int id)
        {
            try
            {
                var item = BasketItemsBusiness.GetBasketItemByID(id);
                return Ok(item);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DTOBasketItems>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetAllBasketItems()
        {
            try
            {
                var items = BasketItemsBusiness.GetAllBasketItems();
                return Ok(items);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult CreateBasketItem([FromBody] DTOBasketItems_Create item)
        {
            try
            {
                var result = BasketItemsBusiness.CreateBasketItem(item);
                if (result.success)
                    return StatusCode(201, new { BasketItemID = result.basketItemID });
                return StatusCode(500, new { message = "Basket item creation failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult UpdateBasketItem([FromBody] DTOBasketItems_Update item)
        {
            try
            {
                if (BasketItemsBusiness.UpdateBasketItem(item))
                    return Ok();
                return StatusCode(500, new { message = "Basket item update failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult DeleteBasketItem(int id)
        {
            try
            {
                if (BasketItemsBusiness.DeleteBasketItem(id))
                    return Ok();
                return StatusCode(500, new { message = "Basket item deletion failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("AddItem")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult AddItemToTheBasket([FromBody] DTOBasketItems_Add item)
        {
            try
            {
                BasketItemsBusiness.AddItemToTheBasket(item);
                return Ok(new { message = "Item added to the basket successfully." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
