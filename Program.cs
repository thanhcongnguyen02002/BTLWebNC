using BTLWebNC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContextPool<MyDbContext>(options =>
// options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// config sesstion
builder.Services.AddSession(options =>
{

});
builder.Services.AddHttpContextAccessor();
// connect sql server
builder.Services.AddDbContextPool<MyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//authorize
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Auth/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(10);
});
// add repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IPostRepository, PostRepositoryImpl>();
builder.Services.AddScoped<IAuthRepository, AuthRepositoryImpl>();
builder.Services.AddScoped<ICommentRepository, CommentRepositoryImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//session
app.UseSession();
//authorize
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
