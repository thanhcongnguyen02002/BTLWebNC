namespace BTLWebNC.Models;
public interface IPostRepository
{
    List<Post> GetAllPost();
    List<Post> GetPostByID(int userID);
    void DeleteByID(int id);
    Post Update(int id, Post post);
}