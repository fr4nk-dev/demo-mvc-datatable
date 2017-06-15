using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace PruebaMotherTravel.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("TravelDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Migrations.Configuration>());
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Origin> Origins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}