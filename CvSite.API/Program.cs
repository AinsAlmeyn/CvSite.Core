using System.Reflection;
using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using CvSite.Core.Services;
using CvSite.DataAccess;
using CvSite.DataAccess.RepoCon;
using CvSite.Services.ServiceCon;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);


string root = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Log\\";
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddFile(root + @"\CvSite_{0:yyyy}-{0:MM}-{0:dd}.log", fileLoggerOpts =>
    {
        fileLoggerOpts.FormatLogFileName = fName =>
        {
            return String.Format(fName, DateTime.UtcNow);
        };
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CvSiteDbContext>();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<CvSiteDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"),
        option =>
        {
            option.MigrationsAssembly(Assembly.GetAssembly(typeof(CvSiteDbContext)).GetName().Name);
        }));

#region Ioc Dependency Injection

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGetInTouchRepositroy), typeof(GetInTouchRepository));
builder.Services.AddScoped(typeof(IHomeRepository), typeof(HomeRepository));
builder.Services.AddScoped(typeof(IHomeService), typeof(HomeService));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(INewAboutService), typeof(NewAboutService));
builder.Services.AddScoped(typeof(INewAboutRepository), typeof(NewAboutRepository));
builder.Services.AddScoped(typeof(IBlogInfoRepository), typeof(BlogInfoRepository));
builder.Services.AddScoped(typeof(IBlogInfoService), typeof(BlogInfoService));
builder.Services.AddScoped(typeof(IAboutSliderRepository), typeof(AboutSliderRepository));
builder.Services.AddScoped(typeof(IAboutSliderService), typeof(AboutSliderService));
builder.Services.AddScoped(typeof(IPortfolioRepository), typeof(PortfolioRepository));
builder.Services.AddScoped(typeof(IPortfolioService), typeof(PortfolioService));
builder.Services.AddScoped(typeof(IGetInTouchRepositroy), typeof(GetInTouchRepository));
builder.Services.AddScoped(typeof(IGetInTouchService), typeof(GetInTouchService));
builder.Services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));
builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));

#endregion


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();