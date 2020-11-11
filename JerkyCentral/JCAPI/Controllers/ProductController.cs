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
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;

        public ProductController(ProductServices service)
        {
            this._productServices = service;
        }
    }
}
