using System;
using System.Data.Entity;
using System.Diagnostics;
using POC.EF.Web.DAL.Configurations.Implementation;
using POC.EF.Web.DAL.Entities.Implementation;

namespace POC.EF.Web.DAL
{
    public class AdventureWorksContext : DbContext
    {
        private Action<DbModelBuilder> ConfigurationApplicator { get; }

        public AdventureWorksContext(string connectionString, Action<DbModelBuilder> configurationApplicator = null)
            : base(connectionString ?? "AdventureWorks")
        {
            ConfigurationApplicator = configurationApplicator ?? (modelBuilder =>
            {
                modelBuilder.Configurations.Add(new AddressConfiguration());
            });

#if DEBUG
            Database.Log = (sql) => Debug.WriteLine(sql);
#endif
        }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AdventureWorksContext>(null);

            modelBuilder.HasDefaultSchema("dbo");

            ConfigurationApplicator(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}