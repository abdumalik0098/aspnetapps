using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();


/*
string connection = "Server = (localdb)\\mssqllocaldb;Database = userstoredb;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("ConnectionStrings:WebAppMVC"));

builder.Services.AddTransient<IProductRepos, EFProductRepos>();

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
    pattern: "{controller=Product}/{action=List}/{id?}");

app.Run();
