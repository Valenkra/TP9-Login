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
            return RedirectToAction("Welcome", "Home");
        }else{
            return RedirectToAction("Index", "Home");
        }
    }

    [HttpPost]
    public IActionResult SignUp(string user, string passw)
    {
        BD.SignUp(user, passw);
        return RedirectToAction("Index", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public IActionResult UpdateMyInfo(string user, string name, string email, string edad){
        BD.UpdateInfo(user, name, edad, email);
        User Personal = BD.GetInfo(user);
        return RedirectToAction("Welcome", "Home");
    }
}