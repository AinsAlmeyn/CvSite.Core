using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSite.Core.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string? AdminUserName { get; set; }
        public string? AdminUserPassword { get; set; }
    }
}
