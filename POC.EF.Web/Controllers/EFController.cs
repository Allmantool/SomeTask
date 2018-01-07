using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using POC.EF.Web.DAL;

namespace POC.EF.Web.Controllers
{
    public class EFController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-9MCCCFM",
                InitialCatalog = "AdventureWorks2014",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }.ToString();

            using (var dbContext = new AdventureWorksContext(connectionString))
            {
                var response1 = dbContext.Addresses.FirstOrDefault(adr => adr.AddressID == id);

                return Ok(response1);
            }
        }
    }
}
