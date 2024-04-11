using System.Security.Claims;
using BTLWebNC.Models;

public class CommentRepositoryImpl : ICommentRepository
{
    private readonly IHttpContextAccessor httpContext;
    private readonly MyDbContext context;
    public CommentRepositoryImpl(MyDbContext context, IHttpContextAccessor httpContext)
    {
        this.context = context;
        this.httpContext = httpContext;
    }
    public Comment CreateComment(int id_post, Comment comment)
    {
        var principal = httpContext.HttpContext.User;
        var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            var resutl = new Comment
            {
                post_id = id_post,
                user_id = userId,
                creatDate = DateTime.Now,
                content = comment.content
            };
            context.Comments.Add(resutl);
            context.SaveChanges();
            return comment;
        }
        return null;
    }

    public void DeleteByID(int id)
    {
        throw new NotImplementedException();
    }

    public List<Comment> GetComments(int id_post)
    {
        return context.Comments.Where(c => c.post_id == id_post).ToList();
    }
}