using System.Data.Entity.ModelConfiguration;
using POC.EF.Web.DAL.Configurations.Interfaces;
using POC.EF.Web.DAL.Entities.Implementation;

namespace POC.EF.Web.DAL.Configurations.Implementation
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>, IEnityConfiguration
    {
        public AddressConfiguration()
        {
            ToTable("Address", "Person");
            Property(adr => adr.AddressID).HasColumnName("AddressID");
            HasKey(adr => adr.AddressID);
        }
    }
}