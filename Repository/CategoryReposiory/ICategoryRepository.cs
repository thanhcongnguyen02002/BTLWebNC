public interface ICategoryRepository
{
    List<Category> GetListAllCategory();
    Category CreateCategory(Category category);
}