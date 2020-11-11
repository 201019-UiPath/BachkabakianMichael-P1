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
    [Route("api/Manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerServices _managerServices;

        public ManagerController(ManagerServices service)
        {
            this._managerServices = service;
        }
    }
}
