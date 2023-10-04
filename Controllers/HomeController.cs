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

    [HttpPost]
    public IActionResult Account(string user, string passw, string requestedType)
    {
        if(requestedType == "login"){
            User usuario = BD.LogIn(user, passw);
            if(usuario != null){
                Persona.Username = usuario.Username;
                Persona.Contraseña = usuario.Contraseña;
                Persona.Edad = usuario.Edad;
                Persona.Email = usuario.Email;
                Persona.Nombre = usuario.Nombre;
                return RedirectToAction("Welcome");
            }else{
                return RedirectToAction("Index");
            }
        }else{
            BD.SignUp(user, passw);
            return RedirectToAction("Index");
        }
    }
    public IActionResult ForgotMyPassword()
    {
        ViewBag.Conectado = false;
        return View();
    }

    public IActionResult SignUp()
    {
        ViewBag.Conectado = false;
        return View();
    }

    public IActionResult Welcome()
    {   
        ViewBag.Conectado = true;
        ViewBag.Name = Persona.Nombre;
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
