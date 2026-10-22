using GymManagementSystem.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o=> {o.LoginPath="/Account/Login"; o.AccessDeniedPath="/Account/Login"; o.Cookie.HttpOnly=true; o.Cookie.SameSite=SameSiteMode.Lax; o.ExpireTimeSpan=TimeSpan.FromHours(8);});
builder.Services.AddAuthorization();
var cs=builder.Configuration.GetConnectionString("GymConnection") ?? throw new Exception("Missing GymConnection");
builder.Services.AddDbContext<GymDbContext>(o=>o.UseMySql(cs,new MySqlServerVersion(new Version(8,0,30))));
// Create the database when the local XAMPP user has CREATE privileges.
var b=new MySqlConnectionStringBuilder(cs); var database=b.Database; b.Database="";
using(var conn=new MySqlConnection(b.ConnectionString)) {conn.Open(); using var cmd=conn.CreateCommand(); cmd.CommandText="CREATE DATABASE IF NOT EXISTS `"+database.Replace("`","``")+"` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci"; cmd.ExecuteNonQuery();}
var app=builder.Build();
using(var scope=app.Services.CreateScope()){var db=scope.ServiceProvider.GetRequiredService<GymDbContext>();db.Database.EnsureCreated();}
if(!app.Environment.IsDevelopment()){app.UseExceptionHandler("/Home/Error");app.UseHsts();}
app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseAuthentication();app.UseAuthorization();
app.MapControllerRoute(name:"default",pattern:"{controller=Home}/{action=Index}/{id?}");app.Run();
