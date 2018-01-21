using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using POC.EF.Web.DAL;
using POC.EF.Web.DAL.Entities;

namespace POC.EF.Web.Controllers
{
    public class EFController : ApiController
    {
        //[Route("api/EF/Narrow/{id:int}")]
        //public IHttpActionResult NarrowGet(int id)
        //{
        //    var connectionString = new SqlConnectionStringBuilder()
        //    {
        //        DataSource = "DESKTOP-9MCCCFM",
        //        InitialCatalog = "AdventureWorks2014",
        //        ConnectTimeout = 30,
        //        IntegratedSecurity = true,
        //        MultipleActiveResultSets = true
        //    }.ToString();

        //    using (var dbContext = new AdventureWorksContext(connectionString))
        //    {
        //        var response1 = dbContext.Addresses.FirstOrDefault(adr => adr.AddressID == id);

        //        return Ok(response1);
        //    }
        //}

        [HttpGet]
        [Route("api/EF/Fat/{id:int}")]
        public IHttpActionResult FatGet(int id)
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-9MCCCFM",
                InitialCatalog = "AdventureWorks2014",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }.ToString();
            var timer = new Stopwatch();
            timer.Start();

            using (var dbContext = new ThickDbContext(connectionString ))
            {
                //dbContext.Configuration.AutoDetectChangesEnabled = false;
                //dbContext.Configuration.LazyLoadingEnabled = false;
                //dbContext.Configuration.ProxyCreationEnabled = false;

                var response = dbContext
                    .Addresses
                    //.AsNoTracking()
                    .Where(adr => adr.AddressID == id)
                    .ToList();

                timer.Stop();

                var result = response
                    .Select(dto => new
                    {
                        dto.AddressID,
                        dto.City,
                        dto.ModifiedDate,
                        dto.PostalCode,
                        timer.Elapsed.Milliseconds
                    });

                return Ok(result);
            }
        }
    }
}
