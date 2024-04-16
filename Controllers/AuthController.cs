using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BTLWebNC.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BTLWebNC.Controllers;

public class AuthController : Controller
{
    private readonly MyDbContext context;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IUserRepository repository;
    private readonly IAuthRepository authRepository;
    public AuthController(IUserRepository repository, IHttpContextAccessor httpContextAccessor, MyDbContext context, IAuthRepository authRepository)
    {
        this.repository = repository;
        this.httpContextAccessor = httpContextAccessor;
        this.context = context;
        this.authRepository = authRepository;


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
    public async Task<IActionResult> Login(User userData)
    {
        if (userData.username == null || userData.password == null)
        {
            return View(userData);
        }
        else
        {
            var checkUsername = context.Users.SingleOrDefault(x => x.username == userData.username && x.password == userData.password);

            if (!PasswordMeetsRequirements(userData.password))
            {
                ModelState.AddModelError("Password", "Mật khẩu cần chứa ít nhất một số và một chữ ");
                return View(userData);
            }
            else if (userData.password.Length < 4)
            {
                ModelState.AddModelError("Password", "Mật khẩu phải lớn hơn 6 ký tự ");
                return View(userData);
            }
            else if (userData.username.Length < 4)
            {
                ModelState.AddModelError("Username", "Tài khoản phải lớn hơn 4 ký tự ");
                return View(userData);
            }

            else if (checkUsername == null)
            {
                ModelState.AddModelError("Username", "Tài khoản không tồn tại hoặc sai mật khẩu ");
                return View(userData);
            }
            else
            {
                httpContextAccessor.HttpContext.Session.SetString("username", userData.username);
                // sử dụng claim
                List<Claim> claims = new List<Claim>()
                {   new Claim(ClaimTypes.NameIdentifier, checkUsername.id.ToString()),
                   // new Claim(ClaimTypes.NameIdentifier, checkUsername.username),
                    new Claim("Email",checkUsername.email),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                if (checkUsername.role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Post");
                }

            }
        }
    }
    // [HttpPost]
    // public async Task<IActionResult> Login(User userData)
    // {
    //     if (userData.username == null || userData.password == null)
    //     {
    //         return View(userData);
    //     }
    //     else
    //     {
    //         var user = context.Users.SingleOrDefault(x => x.username == userData.username && x.password == userData.password);

    //         if (user == null)
    //         {
    //             ModelState.AddModelError("Username", "Tài khoản không tồn tại hoặc sai mật khẩu");
    //             return View(userData);
    //         }
    //         else
    //         {
    //             var claims = new List<Claim>
    //         {
    //             new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
    //             new Claim(ClaimTypes.Name, user.username),
    //             new Claim("Email", user.email),
    //         };

    //             var roles = await userManager.GetRolesAsync(user); // userManager là một instance của UserManager<TUser>

    //             foreach (var role in roles)
    //             {
    //                 claims.Add(new Claim(ClaimTypes.Role, role));
    //             }

    //             var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    //             var principal = new ClaimsPrincipal(identity);

    //             await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
    //             {
    //                 IsPersistent = true,
    //                 ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20) // Thời gian hết hạn của cookie
    //             });

    //             if (roles.Contains("admin"))
    //             {
    //                 return RedirectToAction("CreatePost", "Post");
    //             }
    //             else if (roles.Contains("user"))
    //             {
    //                 return RedirectToAction("Index", "User");
    //             }
    //             else
    //             {
    //                 return RedirectToAction("Index", "Home"); // Chuyển hướng mặc định nếu không có vai trò nào được xác định
    //             }
    //         }
    //     }
    // }

    [HttpPost]
    public IActionResult Register(ResgisterDTO resgisterDTO)
    {
        var result = authRepository.Register(resgisterDTO);
        return View("Login");
    }
    public IActionResult Logout()
    {
        authRepository.Logout();
        return RedirectToAction("Index", "Home");
    }

    private bool PasswordMeetsRequirements(string password)
    {
        // Use a regular expression to check if the password contains at least one letter and one number
        return System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d).+$");
    }
}

