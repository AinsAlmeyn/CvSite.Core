using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CvSite.DataAccess.RepoCon;

public class GetInTouchRepository : GenericRepository<GetInTouch>, IGetInTouchRepositroy
{
    public GetInTouchRepository(CvSiteDbContext context) : base(context)
    {

    }
    public async Task<GetInTouch> GetOneObject()
    {
        return await _context.GetInTouches.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
    }
}