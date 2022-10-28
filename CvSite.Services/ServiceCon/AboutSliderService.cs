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
    public class AboutSliderService : GenericService<AboutSlider>, IAboutSliderService
    {
        public AboutSliderService(IGenericRepository<AboutSlider> repo) : base(repo)
        {
        }
    }
}
