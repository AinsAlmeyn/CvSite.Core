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
    public class NewAboutService : GenericService<NewAbout>, INewAboutService
    {
        private readonly INewAboutRepository _aboutRepository;
        public NewAboutService(IGenericRepository<NewAbout> repo, INewAboutRepository aboutRepository) : base(repo)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<NewAbout> GetOneAbout()
        {
            return await _aboutRepository.GetOneObject();
        }
    }
}
