using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using POC.EF.Web.DAL.Entities.Interfaces;

namespace POC.EF.Web.DAL.Entities.Implementation
{
    [Table("Address", Schema = "Person")]
    public partial class Address : IEntity
    {
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceID { get; set; }
        public string PostalCode { get; set; }
        public DbGeography SpatialLocation { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}