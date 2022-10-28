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
        private readonly CvSiteDbContext _context;
        public HomeRepository(CvSiteDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Home> GetOneObject()
        {
            return await _context.Homes.FirstOrDefaultAsync(x => x.Id == 1);
        }
    }
}
