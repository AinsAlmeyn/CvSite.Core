using CvSite.Core.Entities;
using CvSite.DataAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

//using AppUser = CvSite.Presentation.Models.AdminModels.AppUser;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddFluentValidation(configurationExpression: x => x.RegisterValidatorsFromAssemblyContaining<CvSite.Services.Validations.AboutSliderValidation>());

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<CvSiteDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(CvSiteDbContext)).GetName().Name);
        }));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => { x.LoginPath = "/Account/Login"; });
//builder.Services.AddDbContext<CvSiteDbContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CvSiteDbContext>();


var app = builder.Build();

app.UseAuthentication();
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
    pattern: "{controller=Home}/{action=HomePage}/{id?}");

app.Run();