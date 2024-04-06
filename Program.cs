using BTLWebNC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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


// builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
// builder.Services.AddScoped<IdGioHang, GioHangImpl>();

// add repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IPostRepository, PostRepositoryImpl>();

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

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
