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
        if(Persona.logged == true){
            return RedirectToAction("Welcome");
        }else{
            ViewBag.Conectado = false;
            return View();
        }
    }

    public IActionResult ForgotMyPassword()
    {
        ViewBag.Conectado = false;
        return View();
    }

    public IActionResult Registro(int sms)
    {
        TempData["show"] = sms;
        ViewBag.showSMS = sms;
        ViewBag.Mistake = Errror.Mistake;
        ViewBag.Conectado = false;
        return View("SignUp");
    }

    public IActionResult Welcome()
    {   
        ViewBag.Name = Persona.Nombre;
        ViewBag.User = Persona.Username;
        ViewBag.Email = Persona.Email;
        ViewBag.Edad = Persona.Edad;
        ViewBag.Conectado = true;
        return View();
    }

    public IActionResult Privacy()
    {
        ViewBag.Conectado = false;
        return View();
    }

    public IActionResult Amigos()
    {
        ViewBag.Conectado = true;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
