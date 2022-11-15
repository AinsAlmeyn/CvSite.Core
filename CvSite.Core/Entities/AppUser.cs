using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string NameSurname { get; set; }
    }
}
