using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using POC.EF.Web.DAL;

namespace POC.EF.Tests
{
    [TestFixture()]
    public class EFDbContextTests
    {
        private string connectionString;

        [SetUp]
        public void Setup()
        {
            connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-9MCCCFM",
                InitialCatalog = "AdventureWorks2014",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }.ToString();
        }

        [Test]
        //[Retry(5)]
        public void Get_FirstRequest_EstimatedTime()
        {
            var timer = new Stopwatch();
            using (var dbContext = new AdventureWorksDbContext(connectionString))
            {
                timer.Start();

                var response1 = dbContext.Addresses.Count();

                timer.Stop();

                Assert.LessOrEqual(timer.Elapsed.Seconds, 2);
            }
        }

        [Test]
        public void Get_SimpleConfiguration_EstimatedTime()
        {
            var timer = new Stopwatch();
            using (var dbContext = new SimpleDbContext())
            {
                timer.Start();

                var response1 = dbContext.Addresses.Count();

                timer.Stop();

                Assert.LessOrEqual(timer.Elapsed.Seconds, 2);
            }
        }
    }
}
