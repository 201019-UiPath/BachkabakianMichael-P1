using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JCDB;
using JCDB.Models;
using JCLib;

namespace JCAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartLineController : ControllerBase
    {
        private readonly CartLineServices _cartLineServices;

        public CartLineController(CartLineServices service)
        {
            this._cartLineServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCartLine(CartLine cartLine)
        {
            try
            {
                _cartLineServices.AddCartLine(cartLine);
                return CreatedAtAction("AddCartLine", cartLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCartLine(CartLine cartLine)
        {
            try
            {
                _cartLineServices.UpdateCartLine(cartLine);
                return CreatedAtAction("UpdateCartLine", cartLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCartLine(CartLine cartLine)
        {
            try
            {
                _cartLineServices.DeleteCartLine(cartLine);
                return CreatedAtAction("DeleteCartLine", cartLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{CartId}")]
        [Produces("application/json")]
        public IActionResult GetAllCartLinesByCart(int id)
        {
            try
            {
                return Ok(_cartLineServices.GetAllCartLinesByCart(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
