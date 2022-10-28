using CvSite.Core.Entities;

namespace CvSite.Core.Repositories;

public interface IGetInTouchRepositroy : IGenericRepository<GetInTouch>
{
    Task<GetInTouch> GetOneObject();
}