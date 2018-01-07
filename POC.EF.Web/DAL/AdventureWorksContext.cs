using System.Data.Entity;
using POC.EF.Web.DAL.Entities.Implementation;

namespace POC.EF.Web.DAL
{
    public partial class AdventureWorksContext : DbContext
    {
        public AdventureWorksContext()
            : base("name=AdventureWorks")
        { }

        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AdventureWorksContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}