using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection.Emit;
using Wellnut.Data.Models;

namespace Wellnut.Data
{
    public class WellnutContext:DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }

        public DbSet<UserInformation> UserInformation { get; set; }

        public DbSet<UserHistory> UserHistory { get; set; }

        public DbSet<Exercise> Exercise { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Report> Report { get; set; }

    }
}
