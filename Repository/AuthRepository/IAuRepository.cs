using BTLWebNC.Models;

public interface IAuthRepository
{
    User Register(ResgisterDTO resgisterDTO);
    User Login(User user);
    void Logout();
}