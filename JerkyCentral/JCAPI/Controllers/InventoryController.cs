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
    [Route("api/Inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryServices _inventoryServices;

        public InventoryController(InventoryServices service)
        {
            this._inventoryServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddInventory(Inventory inventory)
        {
            try
            {
                _inventoryServices.AddInventory(inventory);
                return CreatedAtAction("AddInventory", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateInventory(Inventory inventory)
        {
            try
            {
                _inventoryServices.UpdateInventory(inventory);
                return CreatedAtAction("UpdateInventory", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteInventory(Inventory inventory)
        {
            try
            {
                _inventoryServices.DeleteInventory(inventory);
                return CreatedAtAction("DeleteInventory", inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{LocationId}/{ProductId}")]
        [Produces("application/json")]
        public IActionResult GetInventoryByLocationIdProductId(int locationId, int productId)
        {
            try
            {
                return Ok(_inventoryServices.GetInventoryByLocationIdProductId(locationId, productId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("get/{LocationId}")]
        [Produces("application/json")]
        public IActionResult GetAllInventoryItemsByLocationId(int locationId)
        {
            try
            {
                return Ok(_inventoryServices.GetAllInventoryItemsByLocationId(locationId));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
