using Microsoft.EntityFrameworkCore;
using ProjetoBiblioteca.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<Contexto> //Liriany
   (options => options.UseSqlServer("Data Source=SB-1490643\\SQLSENAI;Initial Catalog = PojetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"))*/;

builder.Services.AddDbContext<Contexto> //Manuela
   (options => options.UseSqlServer("Data Source=SB-1490633\\SQLSENAI;Initial Catalog = PojetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"));

/*builder.Services.AddDbContext<Contexto> //Kauan
   (options => options.UseSqlServer("Data Source=SB-1490634\\SQLSENAI;Initial Catalog = PojetoBiblioteca;Integrated Security = True;TrustServerCertificate = True"))*/;


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
