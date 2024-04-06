using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTLWebNC.Models;

namespace BTLWebNC.Controllers;

public class AuthController : Controller
{
    private readonly IUserRepository repository;
    public AuthController(IUserRepository repository)
    {
        this.repository = repository;
    }


    public IActionResult Login()
    {
        return View("Login");
    }
    public IActionResult Register()
    {
        return View("Register");
    }
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var result = repository.Login(username, password);
        return View(result);
        //return View();

    }
    [HttpPost]
    public IActionResult Register(ResgisterDTO resgisterDTO)
    {
        var result = repository.Register(resgisterDTO);
        return View("Login");
    }


}
