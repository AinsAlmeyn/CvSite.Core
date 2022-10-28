using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.DataAccess.RepoCon
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(CvSiteDbContext context) : base(context)
        {
        }
    }
}
