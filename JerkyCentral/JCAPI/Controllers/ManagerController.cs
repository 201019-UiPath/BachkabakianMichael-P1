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
    public class ManagerController : ControllerBase
    {
        private readonly ManagerServices _managerServices;

        public ManagerController(ManagerServices service)
        {
            this._managerServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddManager(Manager manager)
        {
            try
            {
                _managerServices.AddManager(manager);
                return CreatedAtAction("AddManager", manager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateManager(Manager manager)
        {
            try
            {
                _managerServices.UpdateManager(manager);
                return CreatedAtAction("UpdateManager", manager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteManager(Manager manager)
        {
            try
            {
                _managerServices.DeleteManager(manager);
                return CreatedAtAction("DeleteManager", manager);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{ManagerId}")]
        [Produces("application/json")]
        public IActionResult GetManagerById(int id)
        {
            try
            {
                return Ok(_managerServices.GetManagerById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetManagerByName(string name)
        {
            try
            {
                return Ok(_managerServices.GetManagerByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getAll")]
        [Produces("application/json")]
        public IActionResult GetAllManagers()
        {
            try
            {
                return Ok(_managerServices.GetAllManagers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
