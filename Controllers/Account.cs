using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Login.Models;

namespace Login.Controllers;

public class Account : Controller
{
    private readonly ILogger<HomeController> _logger;

    [HttpPost]
    public IActionResult LogIn(string user, string passw)
    {
        User usuario = BD.LogIn(user, passw);
        if(usuario != null){
            IgualarPersona(usuario);
            return RedirectToAction("Welcome", "Home");
        }else{
            return RedirectToAction("Index", "Home");
        }
    }

    private void IgualarPersona(User usuario){
        Persona.Username = usuario.Username;
        Persona.Nombre = usuario.Nombre;
        Persona.Email = usuario.Email;
        Persona.Edad = usuario.Edad;
        Persona.Contrasenia = usuario.Contraseña;
    }

    [HttpPost]
    public IActionResult SignUp(string user, string mail, string passw)
    {
        ViewBag.SMS = BD.SignUp(user, mail, passw);
        Errror.Mistake = "";
        return RedirectToAction("Registro", "Home", new {sms = @ViewBag.SMS});
    
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult UpdateMyInfo(string user, string name, string email, string edad){
        BD.UpdateInfo(user, name, edad, email);
        User Personal = BD.GetInfoFromUser(user);
        IgualarPersona(Personal); 
        return RedirectToAction("Welcome", "Home");
    }
}