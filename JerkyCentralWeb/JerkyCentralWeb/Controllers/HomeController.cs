using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JerkyCentralWeb.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace JerkyCentralWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private const string url = "https://localhost:44360/";

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManagerIndex()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using(var client= new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"api/user/get?name={model.Name}");
                    response.Wait();

                    var result = response.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();

                        var user = JsonConvert.DeserializeObject<User>(data.Result);

                        if (user.PassWord == model.PassWord && user.Name == model.Name)
                        {
                            return RedirectToAction("Index", "Customer");
                        }
                    }
                }
            }
            return View("Index", model);
        }

        public IActionResult ManagerLogin(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    var response = client.GetAsync($"api/manager/get?name={model.Name}");
                    response.Wait();

                    var result = response.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync();
                        data.Wait();

                        var manager = JsonConvert.DeserializeObject<Manager>(data.Result);

                        if (manager.PassWord == model.PassWord && manager.Name == model.Name)
                        {
                            return RedirectToAction("Index", "Manager");
                        }
                    }
                }
            }
            return View("ManagerIndex", model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
