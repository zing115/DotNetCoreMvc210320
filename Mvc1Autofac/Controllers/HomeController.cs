using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc1Autofac.Models;

using Mvc1Autofac.Services;

namespace Mvc1Autofac.Controllers
{
  public class HomeController : Controller
  {
    public UseTheForce UseTheForce { get; set; }

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, UseTheForce UseTheForce)
    {
      _logger = logger;
      this.UseTheForce = UseTheForce;
    }

    public IActionResult Test()
    {
      UseTheForce.Jedi.Name = "Obiwan Kenobi";
      UseTheForce.Cars.Name = "Toyota GR-86";

      return Json(new { UseTheForce.Jedi, UseTheForce.Cars });
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Privacy()
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
