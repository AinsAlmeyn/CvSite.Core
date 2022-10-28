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
    public class HomeRepository : GenericRepository<Home>, IHomeRepository
    {
        public HomeRepository(CvSiteDbContext context) : base(context)
        {

        }

        public async Task<Home> GetOneObject()
        {
            return await _context.Homes.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
