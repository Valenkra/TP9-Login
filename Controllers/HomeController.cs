using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Login.Models;

namespace Login.Controllers;

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

    [HttpPost]
    public IActionResult Account(string user, string passw, string requestedType)
    {
        if(requestedType == "login"){
            User usuario = BD.LogIn(user, passw);
            if(usuario != null){
                Persona.Username = usuario.Username; 
                return RedirectToAction("Welcome");
            }else{
                return RedirectToAction("Index");
            }
        }else{
            BD.SignUp(user, passw);
            return RedirectToAction("Index");
        }
    }

    public IActionResult Home()
    {
        /*
        if(Viewbag. user == true){
            Welcome
        }else{
            index;
        }
        */
        return RedirectToAction("Index");
    }

    public IActionResult ForgotMyPassword()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult Welcome()
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
