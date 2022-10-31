using CvSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CvSite.DataAccess.Configurations;

public class GetInTouchConfiguration : IEntityTypeConfiguration<GetInTouch>
{
    public void Configure(EntityTypeBuilder<GetInTouch> builder)
    {
        builder.HasKey(x => x.Id);
    }
}