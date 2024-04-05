using Microsoft.AspNetCore.Mvc;
namespace BTLWebNC.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryRepository repository;
    public CategoryController(ICategoryRepository repository)
    {
        this.repository = repository;
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<Category> categories = repository.GetListAllCategory();
        return View(categories);
    }
}