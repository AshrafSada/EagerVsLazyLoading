using EagerVsLazyLoading.DataStore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connStr = builder.Configuration.GetConnectionString("appDbConn") ??
    throw new ArgumentNullException("Connection string was null!");

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
{
    _ = options.UseSqlite(connStr);
    _ = options.UseLazyLoadingProxies(true);
});
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    _ = app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
