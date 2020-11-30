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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;

        public CategoryController(CategoryServices service)
        {
            this._categoryServices = service;
        }

        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddCategory(Category category)
        {
            try
            {
                _categoryServices.AddCategory(category);
                return CreatedAtAction("AddCategory", category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("Update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                _categoryServices.UpdateCategory(category);
                return CreatedAtAction("UpdateCategory", category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("Delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteCategory(Category category)
        {
            try
            {
                _categoryServices.DeleteCategory(category);
                return CreatedAtAction("DeleteCategory", category);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get/{CategoryId}")]
        [Produces("application/json")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                return Ok(_categoryServices.GetCategoryById(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get/{CategoryName}")]
        [Produces("application/json")]
        public IActionResult GetCategoryByName(string name)
        {
            try
            {
                return Ok(_categoryServices.GetCategoryByName(name));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllCategories()
        {
            try
            {
                return Ok(_categoryServices.GetAllCategories());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
