using CvSite.Core.Entities;
using CvSite.Core.Repositories;
using CvSite.Core.Services;
using CvSite.DataAccess;
using CvSite.DataAccess.RepoCon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Services.ServiceCon
{
    public class HomeService :  GenericService<Home> ,IHomeService
    {
        private readonly IHomeRepository homeRepository;

        public HomeService(IGenericRepository<Home> repo, IHomeRepository homeRepository) : base(repo)
        {
            this.homeRepository = homeRepository;
        }

        public async Task<Home> GetOneHome()
        {
            return await homeRepository.GetOneObject();
        }
    }
}
