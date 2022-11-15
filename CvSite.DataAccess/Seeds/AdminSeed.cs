using CvSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.DataAccess.Seeds
{
    public class AdminSeed : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasData(new Admin { Id = 1, AdminUserName = "qwertyu", AdminUserPassword = "qwertyu" });
        }
    }
}
