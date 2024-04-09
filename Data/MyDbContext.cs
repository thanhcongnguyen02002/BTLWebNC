using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BTLWebNC.Models;
public class MyDbContext : IdentityDbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Post>()
    //         .HasOne(p => p.User)
    //         .WithMany(u => u.posts)
    //         .HasForeignKey(p => p.user_id);
    //     modelBuilder.Entity<Post>()
    //     .HasOne(p => p.Category)
    //     .WithMany(c => c.posts)
    //     .HasForeignKey(p => p.category_id);
    // }


}