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
    [Route("api/OrderLine")]
    [ApiController]
    public class OrderLineController : ControllerBase
    {
        private readonly OrderLineServices _orderLineServices;

        public OrderLineController(OrderLineServices service)
        {
            this._orderLineServices = service;
        }
    }
}
