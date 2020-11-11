﻿using System;
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
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartServices _cartServices;

        public CartController(CartServices service)
        {
            this._cartServices = service;
        }

        [HttpGet("get/{CartId}")]
        [Produces("application/json")]
        public IActionResult GetCartById(int id)
        {
            try
            {
                return Ok(_cartServices.GetCartById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{UserId}")]
        [Produces("application/json")]
        public IActionResult GetCartByUserId(int id)
        {
            try
            {
                return Ok(_cartServices.GetCartByUserId(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
