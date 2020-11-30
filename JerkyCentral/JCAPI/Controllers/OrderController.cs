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
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _orderServices;

        public OrderController(OrderServices service)
        {
            this._orderServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddOrder(Order order)
        {
            try
            {
                _orderServices.AddOrder(order);
                return CreatedAtAction("AddOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateOrder(Order order)
        {
            try
            {
                _orderServices.UpdateOrder(order);
                return CreatedAtAction("UpdateOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteOrder(Order order)
        {
            try
            {
                _orderServices.DeleteOrder(order);
                return CreatedAtAction("DeleteOrder", order);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{OrderId}")]
        [Produces("application/json")]
        public IActionResult GetOrderById(int id)
        {
            try
            {
                return Ok(_orderServices.GetOrderById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{OrderDate}")]
        [Produces("application/json")]
        public IActionResult GetOrderByDate(DateTime date)
        {
            try
            {
                return Ok(_orderServices.GetOrderByDate(date));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/user/{UserId}")]
        [Produces("application/json")]
        public IActionResult GetOrdersByUserId(int id)
        {
            try
            {
                return Ok(_orderServices.GetOrdersByUserId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/location/{LocationId}")]
        [Produces("application/json")]
        public IActionResult GetOrdersByLocationId(int id)
        {
            try
            {
                return Ok(_orderServices.GetOrdersByLocationId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllOrders()
        {
            try
            {
                return Ok(_orderServices.GetAllOrders());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
