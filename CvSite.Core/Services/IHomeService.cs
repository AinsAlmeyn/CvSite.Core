using CvSite.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Core.Services
{
    public interface IHomeService : IGenericService<Home>
    {
        Task<Home> GetOneHome();
    }
}
