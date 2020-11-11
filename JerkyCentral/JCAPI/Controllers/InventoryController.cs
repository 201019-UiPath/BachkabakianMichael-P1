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
    }
}
