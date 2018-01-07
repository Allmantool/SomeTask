using System.Diagnostics;
using NUnit.Framework;
using POC.EF.Web.DAL;
using System.Linq;

namespace POC.EF.Tests
{
    [TestFixture()]
    public class EFDbContextTests
    {
        [Test]
        public void Get_FirstRequest_EstimatedTime()
        {
            var timer = new Stopwatch();
            using (var dbContext = new AdventureWorksContext())
            {
                var warmRequest = dbContext.Addresses.Count();

                timer.Start();

                var response1 = dbContext.Addresses.Count();

                timer.Stop();
                Assert.LessOrEqual(timer.Elapsed.Seconds, 2);
                //var response2 = dbContext.Addresses.AsNoTracking().OrderBy(adr => adr.AddressID).Skip(1000).Take(1000).ToList();
            }
        }
    }
}
