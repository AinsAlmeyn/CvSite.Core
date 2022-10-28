using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.DataAccess.RepoCon
{
    public class NewAboutRepository : GenericRepository<NewAbout>, INewAboutRepository
    {
        public NewAboutRepository(CvSiteDbContext context) : base(context)
        {
        }

        public async Task<NewAbout> GetOneObject()
        {
            return await _context.NewAbouts.OrderByDescending(x => x.NewId).FirstOrDefaultAsync();
        }
    }
}
