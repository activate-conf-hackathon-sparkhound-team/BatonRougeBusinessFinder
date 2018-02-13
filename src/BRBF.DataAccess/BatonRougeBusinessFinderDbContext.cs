using BRBF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BRBF.DataAccess
{
    public class BatonRougeBusinessFinderDbContext : DbContext
    {
        public BatonRougeBusinessFinderDbContext()
        {

        }

        public BatonRougeBusinessFinderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RegisteredBusiness> RegisteredBusinesses { get; set; }
    }
}
