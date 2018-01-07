using POC.EF.Web.DAL;
using System.Linq;
using System.Web.Http;

namespace POC.EF.Web.Controllers
{
    public class EFController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (var dbContext = new AdventureWorksContext())
            {
                var responseData = dbContext.Addresses.ToList();

                return Ok(responseData);
            }
        }
    }
}
