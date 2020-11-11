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
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _orderServices;

        public OrderController(OrderServices service)
        {
            this._orderServices = service;
        }
    }
}
