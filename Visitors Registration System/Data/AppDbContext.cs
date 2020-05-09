using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Visitors_Registration_System.Entities;

namespace Visitors_Registration_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Visitation> Visitation { get; set; }
        public DbSet<Visitors> Visitors { get; set; }
    }
}
