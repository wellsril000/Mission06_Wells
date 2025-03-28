using Microsoft.EntityFrameworkCore;
using Mission06_Wells.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MovieCollectionContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:BlahConnection"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
// server static files from the wwwroot folder
app.UseStaticFiles(); // enables static file middleware

// set up the routing middleware
app.UseRouting();

// Other middleware (e.g., static files, authentication)
app.UseAuthorization();

app.MapControllerRoute( 
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();