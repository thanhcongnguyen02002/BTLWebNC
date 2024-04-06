using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;
namespace BTLWebNC.Controllers;
public class PostController : Controller
{
    private readonly IPostRepository repository;
    public PostController(IPostRepository repository)
    {
        this.repository = repository;
    }
    public IActionResult Index()
    {
        List<Post> posts = repository.GetAllPost();
        return View(posts);
    }

}