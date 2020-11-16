using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JerkyCentralWeb.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JerkyCentralWeb.Controllers
{
    public class ManagerController : Controller
    {
        private const string url = "https://localhost:44360/";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LocationSelect(Location model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var response = client.GetAsync($"location/getAll");
                response.Wait();

                var result = response.Result;

                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();

                    var locations = JsonConvert.DeserializeObject<List<Location>>(data.Result);
                    var locationOptions = new List<SelectListItem>();

                    foreach (var l in locations)
                    {
                        locationOptions.Add(new SelectListItem { Selected = false, Text = $"{l.LocationName}", Value = l.LocationId.ToString() });
                    }
                    ViewBag.locationOptions = locationOptions;
                }
            }
            return View("Index", model);
        }

        public IActionResult ManagerOptions()
        {
            return View();
        }

        public IActionResult ReplenishInventory()
        {
            return View();
        }

        public IActionResult LocationInventory()
        {
            return View();
        }

        public IActionResult OrderHistoryLocation()
        {
            return View();
        }
    }


}
