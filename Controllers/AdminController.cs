using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly IDisableRepository disable;
    private readonly IPostRepository postRepository;

    public AdminController(IPostRepository postRepository, IDisableRepository disable)
    {
        this.postRepository = postRepository;
        this.disable = disable;
    }
    public IActionResult Index()
    {
        return View("Index");
    }
    public IActionResult ListPost()
    {
        var result = postRepository.GetAllPost();
        return View(result);
    }
    public IActionResult Disable(int id)
    {
        var result = disable.AddDisable(id);
        return Json(new { success = true });
    }
}