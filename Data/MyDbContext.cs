using Microsoft.EntityFrameworkCore;
namespace BTLWebNC.Models;
public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }

}