namespace BTLWebNC.Models;
public interface IPostRepository
{
    List<Post> GetAllPost();
    List<Post> GetPostByID();
    void DeleteByID(int id);
    Post Update(int id, Post post);
    Post CreatePost(Post post);
}