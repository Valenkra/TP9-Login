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
        if(BD.GetInfoFromUser(user) == null && BD.GetInfoFromUser(mail) == null){
            BD.SignUp(user, mail, passw);
            Errror.Mistake = "";
            return RedirectToAction("Welcome", "Home");
        }else{
            if(BD.GetInfoFromUser(user) != null){
                Errror.Mistake = "Ese usuario ya esta en uso, pruebe agregando letras o numeros";
            }else if(BD.GetInfoFromUser(mail) != null){
                Errror.Mistake = "Ese mail ya esta en uso, pruebe iniciando sesion";
            }
            return RedirectToAction("Registro", "Home");
        }
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