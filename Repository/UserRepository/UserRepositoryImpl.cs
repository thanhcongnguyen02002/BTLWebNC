using Microsoft.AspNetCore.Http;

namespace BTLWebNC.Models;

public class UserRepositoryImpl : IUserRepository
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly MyDbContext context;
    public UserRepositoryImpl(MyDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        this.context = context;
        this.httpContextAccessor = httpContextAccessor;
    }
    public void DisableAccount(int id)
    {
        var findById = context.Users.ToList().FirstOrDefault(u => u.id == id);
        if (findById != null)
        {
            var result = new User
            {
                status = false
            };
            context.Users.Update(result);
        }

    }

    public List<User> GetListUser()
    {
        return context.Users.ToList();
    }

    public User Login(string username, string password)
    {
        var result = context.Users.FirstOrDefault(u => u.username == username && u.password == password);
        if (result != null)
        {
            httpContextAccessor.HttpContext.Session.SetString("username", username);
        }
        else
        {

        }
        return result;

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

    public User UpdateAccount(User user)
    {
        throw new NotImplementedException();
    }
}