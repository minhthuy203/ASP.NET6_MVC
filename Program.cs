using Microsoft.EntityFrameworkCore;
using MVC_Csharp.DatabaseContext;

var builder = WebApplication.CreateBuilder(args);
var connectionstring = builder.Configuration.GetConnectionString("MvcConnetionString") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found'");
builder.Services.AddDbContext<MvcDBContext>(options =>
{
    options.UseSqlServer(connectionstring);
});
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
