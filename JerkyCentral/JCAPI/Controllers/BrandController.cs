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
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandServices _brandServices;

        public BrandController(BrandServices service)
        {
            this._brandServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddBrand(Brand brand)
        {
            try
            {
                _brandServices.AddBrand(brand);
                return CreatedAtAction("AddBrand", brand);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateBrand(Brand brand)
        {
            try
            {
                _brandServices.UpdateBrand(brand);
                return CreatedAtAction("UpdateBrand", brand);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteBrand(Brand brand)
        {
            try
            {
                _brandServices.DeleteBrand(brand);
                return CreatedAtAction("DeleteBrand", brand);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{BrandId}")]
        [Produces("application/json")]
        public IActionResult GetBrandById(int id)
        {
            try
            {
                return Ok(_brandServices.GetBrandById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{BrandName}")]
        [Produces("application/json")]
        public IActionResult GetBrandByName(string name)
        {
            try
            {
                return Ok(_brandServices.GetBrandByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllBrands()
        {
            try
            {
                return Ok(_brandServices.GetAllBrands());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    } 
}

