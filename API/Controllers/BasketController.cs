using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;
using BAL;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Basket")]
    public class BasketController : ControllerBase
    {
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DTOBasket), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetBasketByID(int id)
        {
            try
            {
                var basket = BasketBusiness.GetBasketByID(id);
                return Ok(basket);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DTOBasket>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetAllBaskets()
        {
            try
            {
                var baskets = BasketBusiness.GetAllBaskets();
                return Ok(baskets);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult CreateBasket([FromBody] DTOBasket_CreatBasket basket)
        {
            try
            {
                var result = BasketBusiness.CreateBasket(basket);
                if (result.success)
                    return StatusCode(201, new { BasketID = result.basketID });
                return StatusCode(500, new { message = "Basket creation failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //[HttpPut]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(typeof(string), 500)]
        //public IActionResult UpdateBasket([FromBody] DTOBasket basket)
        //{
        //    try
        //    {
        //        if (BasketBusiness.UpdateBasket(basket))
        //            return Ok();
        //        return StatusCode(500, new { message = "Basket update failed." });
        //    }
        //    catch (ApplicationException ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult DeleteBasket(int id)
        {
            try
            {
                if (BasketBusiness.DeleteBasket(id))
                    return Ok();
                return StatusCode(500, new { message = "Basket deletion failed." });
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("{userID}/Items")]
        [ProducesResponseType(typeof(List<DTOBasketItemDetails>), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public IActionResult GetBasketItems(int userID)
        {
            try
            {
                var items = BasketBusiness.GetBasketItems(userID);
                return Ok(items);
            }
            catch (ApplicationException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
