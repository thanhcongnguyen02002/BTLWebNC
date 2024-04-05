namespace BTLWebNC.Models;
public interface IUserRepository
{
    List<User> GetListUser();
    User Register(User user);
    void DisableAccount(int id);
    User UpdateAccount(User user);
    // User Login(string username, string password);
}