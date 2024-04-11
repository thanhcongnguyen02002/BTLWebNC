using BTLWebNC.Models;

public interface ICommentRepository
{
    Comment CreateComment(int id_post, Comment comment);
    List<Comment> GetComments(int id_post);
    void DeleteByID(int id);
}