using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;
namespace BTLWebNC.Controllers;
public class UserController : Controller
{
    private readonly IUserRepository repository;
    public UserController(IUserRepository repository)
    {
        this.repository = repository;
    }
    public IActionResult Index()
    {
        List<User> users = repository.GetListUser();
        return View(users);
    }
    public IActionResult DisableAccount(int id)
    {
        repository.DisableAccount(id);
        return View("Index");
    }
    public IActionResult Register(ResgisterDTO resgisterDTO)
    {
        var result = repository.Register(resgisterDTO);
        return View(result);
    }
}