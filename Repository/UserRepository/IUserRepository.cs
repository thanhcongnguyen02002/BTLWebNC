namespace BTLWebNC.Models;
public interface IUserRepository
{
    List<User> GetListUser();
    void DisableAccount(int id);
    User UpdateAccount(User user);
    Task<User> Login(LoginDTO loginDTO);
    string GetRoleByUsername(string username);
    User MyProfile();
    User getUserByID(int id);
}