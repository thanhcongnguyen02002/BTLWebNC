
namespace BTLWebNC.Models;
public class UserRepositoryImpl : IUserRepository
{
    private readonly MyDbContext context;
    public UserRepositoryImpl(MyDbContext context)
    {
        this.context = context;
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

    public User Register(User user)
    {
        throw new NotImplementedException();
    }

    public User UpdateAccount(User user)
    {
        throw new NotImplementedException();
    }
}