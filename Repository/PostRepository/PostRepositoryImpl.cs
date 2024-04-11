using System.Security.Claims;
using BTLWebNC.Models;
using Microsoft.EntityFrameworkCore;


public class PostRepositoryImpl : IPostRepository
{

    private readonly MyDbContext context;
    private readonly IHttpContextAccessor httpContextAccessor;
    public PostRepositoryImpl(MyDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.httpContextAccessor = httpContextAccessor;
    }

    public Post CreatePost(Post post)
    {
        var principal = httpContextAccessor.HttpContext.User;
        var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            // Truy xuất thông tin người dùng từ cơ sở dữ liệu dựa vào ID
            // var user = context.Posts.FirstOrDefault(p => p.user_id == userId);

            Post result = new Post
            {
                user_id = userId,
                category_id = post.category_id,
                title = post.title,
                content = post.content,
                thumbnail = post.thumbnail,
                createDate = DateTime.Now,
                updateDate = DateTime.Now,
                status = true
            };
            context.Posts.Add(result);
            context.SaveChanges();
            return post;

        }
        return null;
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
    {// include quy xac dinh du lieu rang buoc cung duoc truy van cung du lieu chinh
        return context.Posts.Include(i => i.User).ToList();
    }

    public List<Post> GetPostByID()
    {
        var principal = httpContextAccessor.HttpContext.User;
        var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            // Truy xuất thông tin người dùng từ cơ sở dữ liệu dựa vào ID
            var user = context.Posts.FirstOrDefault(p => p.user_id == userId);
            if (user != null)
            {
                var listpost = context.Posts.Where(p => p.user_id == userId).Include(i => i.User).ToList();
                return listpost;
            }
        }
        return null;
        // return context.Posts.Where(p => p.user_id == userID).ToList();
    }

    public Post Update(int id, Post post)
    {
        throw new NotImplementedException();
    }
}