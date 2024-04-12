using BTLWebNC.Models;
using Microsoft.AspNetCore.Mvc;

public class CommentController : Controller
{
    private readonly MyDbContext context;
    private readonly ICommentRepository repository;
    public CommentController(MyDbContext context, ICommentRepository repository)
    {
        this.context = context;
        this.repository = repository;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetCommentByIdPost(int id)
    {
        var resutl = repository.GetComments(id);
        //  return View(resutl);
        // return PartialView("_CommentsPartial", resutl);
        return Json(resutl);
    }
    [HttpPost]
    public IActionResult CreateComment(int id_post, [FromBody] Comment comment)
    {
        var resutl = repository.CreateComment(id_post, comment);
        return Json(new { success = true });
    }
}