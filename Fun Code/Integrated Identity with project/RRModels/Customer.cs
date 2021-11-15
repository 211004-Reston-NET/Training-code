using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRModels
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }

        public List<Restaurant> Restaurants { get; set; }
    }
}
