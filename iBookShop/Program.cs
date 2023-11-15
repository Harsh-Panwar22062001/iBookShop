using iBookShop.Models.Domain;
using iBookShop.Repositories.Abstract;
using iBookShop.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddScoped<IGenreService,GenreService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment()) 
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Genre}/{action=Add}/{id?}");

app.Run();
