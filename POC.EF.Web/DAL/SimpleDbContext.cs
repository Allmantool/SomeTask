using System.Data.Entity;
using POC.EF.Web.DAL.Entities.Implementation;

namespace POC.EF.Web.DAL
{
    public class SimpleDbContext : DbContext
    {
        public SimpleDbContext() : base("AdventureWorks")
        {
        }

        public DbSet<AddressSimple> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SimpleDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}