using BTLWebNC.Models;


public class PostRepositoryImpl : IPostRepository
{

    private readonly MyDbContext context;
    public PostRepositoryImpl(MyDbContext context)
    {
        this.context = context;
    }
    public void DeleteByID(int id)
    {
        var result = context.Posts.FirstOrDefault(p => p.id == id);
        if (result != null)
        {
            context.Posts.Remove(result);
            context.SaveChanges();
        }

    }

    public List<Post> GetAllPost()
    {
        return context.Posts.ToList();
    }

    public List<Post> GetPostByID(int userID)
    {
        return context.Posts.Where(p => p.user_id == userID).ToList();
    }

    public Post Update(int id, Post post)
    {
        throw new NotImplementedException();
    }
}