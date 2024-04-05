using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTLWebNC.Models;

namespace BTLWebNC.Controllers;

public class AuthController : Controller
{


    public IActionResult Login()
    {
        return View("Login");
    }
    public IActionResult Register()
    {
        return View("Register");
    }


}
