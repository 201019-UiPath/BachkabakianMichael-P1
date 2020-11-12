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
    [Route("api/OrderLine")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly OrderLineServices _orderLineServices;

        public OrderLineController(OrderLineServices service)
        {
            this._orderLineServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrderLine(OrderLine orderLine)
        {
            try
            {
                _orderLineServices.AddOrderLine(orderLine);
                return CreatedAtAction("AddOrderLine", orderLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrderLine(OrderLine orderLine)
        {
            try
            {
                _orderLineServices.UpdateOrderLine(orderLine);
                return CreatedAtAction("UpdateOrderLine", orderLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrderLine(OrderLine orderLine)
        {
            try
            {
                _orderLineServices.DeleteOrderLine(orderLine);
                return CreatedAtAction("DeleteOrderLine", orderLine);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllOrderLines()
        {
            try
            {
                return Ok(_orderLineServices.GetAllOrderLines());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
