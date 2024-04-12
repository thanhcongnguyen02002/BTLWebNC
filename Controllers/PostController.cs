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
    public IActionResult CreatePost()
    {
        return View("AddPost");
    }
    [HttpPost]
    public IActionResult CreatePost(Post post)
    {
        var result = repository.CreatePost(post);
        return RedirectToAction("Index");

    }
    [HttpDelete("DeleteByID/{id}")]
    public IActionResult DeleteById(int id)
    {
        repository.DeleteByID(id);
        return Json(new { success = true });
    }
    public IActionResult UpdatePost(int id, Post post)
    {
        var result = repository.Update(id, post);
        return View(result);
    }

}