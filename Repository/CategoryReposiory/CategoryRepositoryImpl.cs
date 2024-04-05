
using BTLWebNC.Models;

public class CategoryRepositoryImpl : ICategoryRepository
{
    private readonly MyDbContext context;
    public CategoryRepositoryImpl(MyDbContext context)
    {
        this.context = context;
    }

    public Category CreateCategory(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
        return category;
    }

    public List<Category> GetListAllCategory()
    {
        return context.Categories.ToList();
    }
}