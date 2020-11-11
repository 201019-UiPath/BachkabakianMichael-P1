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
    [Route("api/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;

        public CategoryController(CategoryServices service)
        {
            this._categoryServices = service;
        }
    }
}
