using CvSite.Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace CvSite.DataAccess.Configurations;

public class NewAboutConfig : IEntityTypeConfiguration<NewAbout>
{
    public void Configure(EntityTypeBuilder<NewAbout> builder)
    {

        builder.HasKey(x => x.NewId);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(600);

        builder.Property(x => x.Photo)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(100);

    }
}