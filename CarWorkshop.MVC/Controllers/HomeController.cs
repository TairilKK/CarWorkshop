using System.Diagnostics;
using CarWorkshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers;

public class HomeController : Controller 
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult NoAccess()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        var model = new AboutModel()
        {
            Title = "About",
            Description = "Description",
            Tags = ["beard", "meats", "food"]
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
