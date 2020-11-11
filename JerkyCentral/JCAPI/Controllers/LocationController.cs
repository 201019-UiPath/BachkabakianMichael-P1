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
    [Route("api/Location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationServices _locationServices;

        public LocationController(LocationServices service)
        {
            this._locationServices = service;
        }
    }
}
