using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using CvSite.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.ServiceCon
{
    public class BlogInfoService : GenericService<BlogInfo>, IBlogInfoService
    {
        public BlogInfoService(IGenericRepository<BlogInfo> repo) : base(repo)
        {
        }
    }
}
