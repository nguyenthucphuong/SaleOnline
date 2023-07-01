using Microsoft.EntityFrameworkCore;
using SaleOnline.Models;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SaleOnline1Context>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("ketnoi"));
});

//builder.Services.AddScoped<CategoryService>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
//app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "custom",
//        pattern: "Home",
//        defaults: new { controller = "Home", action = "Index" }
//    );
//});


//app.MapControllerRoute(
//    name: "AdminArea",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "AdminArea",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
