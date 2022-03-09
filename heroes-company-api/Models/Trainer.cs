using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace heroes_company_api.Models
{
    public class Trainer : IdentityUser
    {
        public List<Hero> Heroes { get; set; }
    }
}
