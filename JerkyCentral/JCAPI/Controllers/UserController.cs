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
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;

        public UserController(UserServices service)
        {
            this._userServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddUser(User user)
        {
            try
            {
                _userServices.AddUser(user);
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateUser(User user)
        {
            try
            {
                _userServices.UpdateUser(user);
                return CreatedAtAction("UpdateUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteUser(User user)
        {
            try
            {
                _userServices.DeleteUser(user);
                return CreatedAtAction("DeleteUser", user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{UserId}")]
        [Produces("application/json")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                return Ok(_userServices.GetUserById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{Name}")]
        [Produces("application/json")]
        public IActionResult GetUserByName(string name)
        {
            try
            {
                return Ok(_userServices.GetUserByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userServices.GetAllUsers());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
