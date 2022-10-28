using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CvSite.DataAccess.RepoCon;

public class GetInTouchRepository : GenericRepository<GetInTouch>, IGetInTouchRepositroy
{
    private readonly CvSiteDbContext _context;
    public GetInTouchRepository(CvSiteDbContext context) : base(context)
    {
        _context = context;
    }
}