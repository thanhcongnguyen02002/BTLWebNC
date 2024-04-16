using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;
namespace BTLWebNC.Controllers;
public class UserController : Controller
{
    private readonly IUserRepository repository;
    private readonly IPostRepository postRepository;
    public UserController(IUserRepository repository, IPostRepository postRepository)
    {
        this.repository = repository;
        this.postRepository = postRepository;
    }
    public IActionResult Index()
    {
        // List<User> users = repository.GetListUser();
        // return View(users);
        return View("MyProfile");
    }
    public IActionResult DisableAccount(int id)
    {
        repository.DisableAccount(id);
        return View("Index");
    }

    public IActionResult MyProfile()
    {
        var myprofile = new MyProfile();
        var user = repository.MyProfile();
        List<Post> posts = postRepository.GetPostByID();
        if (user != null)
        {
            myprofile.User = user;
            myprofile.Posts = posts;
            return View(myprofile);
        }
        return RedirectToAction("Index", "Post");

    }
    [HttpGet]
    public IActionResult getUserByID(int id)
    {
        var result = repository.getUserByID(id);
        return Json(result);
    }
    [HttpGet]
    public IActionResult getAllUser()
    {
        var result = repository.GetListUser();

        return View("Index", result);

    }
}