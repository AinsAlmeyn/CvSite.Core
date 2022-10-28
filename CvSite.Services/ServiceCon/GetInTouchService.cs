using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using CvSite.Core.Services;
using CvSite.DataAccess.RepoCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.ServiceCon
{
    public class GetInTouchService : GenericService<GetInTouch>, IGetInTouchService
    {
        private readonly IGetInTouchRepositroy _repository;
        public GetInTouchService(IGenericRepository<GetInTouch> repo, IGetInTouchRepositroy repository) : base(repo)
        {
            _repository = repository;
        }

        public async Task<GetInTouch> GetOneTouch()
        {
            return await _repository.GetOneObject();
        }
    }
}
