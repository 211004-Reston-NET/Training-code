using Microsoft.AspNetCore.Identity.EntityFrameworkCore; //Needs to add package
using Microsoft.EntityFrameworkCore;
using RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRDL
{
    //You do the same process of dotnet-ef migration add and dotnet-ef database update
    //I'll let you figure out the arguements you'll probably need to change to tell cli to pick this dbcontext and not the other one
    public class RRIdentityDbContext : IdentityDbContext //Used a different dbContext class that uses identity
    {
        public RRIdentityDbContext()
        {

        }

        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        public RRIdentityDbContext(DbContextOptions<RRIdentityDbContext> options) : base(options)
        {

        }
    }
}
