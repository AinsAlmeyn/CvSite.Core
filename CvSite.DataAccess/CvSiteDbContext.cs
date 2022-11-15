using System.Reflection;
using CvSite.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CvSite.DataAccess;

public class CvSiteDbContext : IdentityDbContext<AppUser,AppRole,int>
{
    public CvSiteDbContext(DbContextOptions<CvSiteDbContext> options):base(options)
    {
        
    }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CvSiteDbContext)));
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<NewAbout> NewAbouts { get; set; }
    public DbSet<BlogInfo> BlogInfos { get; set; }
    public DbSet<Footer> Footers { get; set; }
    public DbSet<GetInTouch> GetInTouches { get; set; }
    public DbSet<Home> Homes { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Admin> Admins { get; set; }
}