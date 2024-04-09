using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
    public string GetRoleByUsername(string username)
    {
        var user = context.Users.First(u => u.username == username);
        if (user != null)
        {
            return user.role;
        }

        return null;
    }

    public async Task<User> Login(LoginDTO loginDTO)
    {
        var result = context.Users.FirstOrDefault(u => u.username == loginDTO.username && u.password == loginDTO.password);
        if (result != null)
        {
            httpContextAccessor.HttpContext.Session.SetString("username", loginDTO.username);
        }
        else
        {

        }
        return result;



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




    public User UpdateAccount(User user)
    {
        throw new NotImplementedException();
    }

    public User MyProfile()
    {
        var principal = httpContextAccessor.HttpContext.User;
        var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
        {
            // Truy xuất thông tin người dùng từ cơ sở dữ liệu dựa vào ID
            var user = context.Users.SingleOrDefault(u => u.id == userId);

            if (user != null)
            {

                // var userPosts = context.Posts.Where(p => p.user_id == userId).ToList();
                var myuser = context.Users.FirstOrDefault(u => u.id == userId);
                return myuser;
            }
        }
        return null;
    }

}
