using BTLWebNC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class AuthRepositoryImpl : IAuthRepository
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly MyDbContext context;

    public AuthRepositoryImpl(IHttpContextAccessor httpContextAccessor, MyDbContext context)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.context = context;
    }
    public User Login(User user)
    {
        throw new NotImplementedException();
    }

    public async void Logout()
    {
        httpContextAccessor.HttpContext.Session.Clear();
        await httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    public User Register(ResgisterDTO resgisterDTO)
    {
        User user = new User
        {
            email = resgisterDTO.email,
            username = resgisterDTO.username,
            password = resgisterDTO.password,
            avatar = resgisterDTO.avatar,
            status = true,
            role = "user",
            createDate = DateTime.Now
        };
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}