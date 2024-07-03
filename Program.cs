using Microsoft.EntityFrameworkCore;
using NewApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;
builder.Services.AddDbContext<CandidateDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
   var serverVersion = ServerVersion.AutoDetect(connectionString);

    options.UseMySql(connectionString, serverVersion);
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy => policy.WithOrigins("http://example.com", "http://www.contoso.com")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseForwardedHeaders(); // Place it here
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "code",
        pattern: "code",
        defaults: new { controller = "Home", action = "code" });
    endpoints.MapControllerRoute(
        name: "code",
        pattern: "code",
        defaults: new { controller = "Home", action = "Login" });

    // Your existing default route
    endpoints.MapControllerRoute(
        name: "Test",
        pattern: "",
        defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllerRoute(
     name: "career",
     pattern: "career",
     defaults: new { controller = "Home", action = "career" });
    endpoints.MapControllerRoute(
   name: "Dashboard",
   pattern: "Dashboard",
   defaults: new { controller = "Home", action = "Dashboard" });

    endpoints.MapControllerRoute(
        name: "Councellor",
        pattern: "Councellor",
         defaults: new { controller = "Home", action = "Councellor" });
    endpoints.MapControllerRoute(
      name: "Index",
      pattern: "Index",
       defaults: new { controller = "Home", action = "Index" });
    endpoints.MapControllerRoute(
    name: "Test",
    pattern: "Test",
     defaults: new { controller = "Home", action = "Test" });
    endpoints.MapControllerRoute(
    name: "Astro",
    pattern: "Astro",
     defaults: new { controller = "Home", action = "Astro" });
    endpoints.MapControllerRoute(
 name: "RefundPolicy",
 pattern: "RefundPolicy",
  defaults: new { controller = "Home", action = "RefundPolicy" });
    endpoints.MapControllerRoute(
 name: "AboutUs",
 pattern: "AboutUs",
  defaults: new { controller = "Home", action = "AboutUs" });

    endpoints.MapControllerRoute(
   name: "Privacy",
   pattern: "Privacy",
    defaults: new { controller = "Home", action = "Privacy" });
    endpoints.MapControllerRoute(
 name: "graph",
 pattern: "graph",
  defaults: new { controller = "Home", action = "graph" });



});

app.Run();
