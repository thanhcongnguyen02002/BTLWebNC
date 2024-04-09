using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTLWebNC.Models;
using System.Security.Claims;

namespace BTLWebNC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()

    {
        var userClaims = User.Identity as ClaimsIdentity;
        if (userClaims != null)
        {
            // Find the claim by its type (ClaimTypes.NameIdentifier in this case)
            // var usernameClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier);
            // var tenusername = userClaims.FindFirst("UseName");
            // var name = userClaims.FindFirst("Name");
            // var email = userClaims.FindFirst("Email");
            // var phone = userClaims.FindFirst("Phone");
            // var id_user = userClaims.FindFirst("id_user");
            // if (usernameClaim != null)
            // {
            //     string username1 = tenusername.Value;
            //     string tendangnhap = name.Value;
            //     string emaildangnhap = email.Value;
            //     string phonedangnhap = phone.Value;
            //     string id = id_user.Value;
            //     TempData["Username"] = username1;
            //     TempData["LoginData"] = usernameClaim;
            //     TempData["LoginData_name"] = tendangnhap;
            //     TempData["LoginEmail"] = emaildangnhap;
            //     TempData["LoginPhone"] = phonedangnhap;
            //     TempData["id_user"] = id;
            //     // Now, 'username' contains the value of the Claim with ClaimTypes.NameIdentifier.
            // }

            // You can also access your custom claim ("OtherProperties" in this case) in a similar manner.
        }
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
