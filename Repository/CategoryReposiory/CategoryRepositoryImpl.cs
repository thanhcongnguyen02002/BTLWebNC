
using BTLWebNC.Models;

public class CategoryRepositoryImpl : ICategoryRepository
{
    private readonly MyDbContext context;
    public CategoryRepositoryImpl(MyDbContext context)
    {
        this.context = context;
    }
    public List<Category> GetListAllCategory()
    {
        return context.Categories.ToList();
    }
}