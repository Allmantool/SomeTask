using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using InteractivePreGeneratedViews;
using NUnit.Framework;
using POC.EF.Web.DAL;

namespace POC.EF.Tests
{
    [TestFixture()]
    public class EntityFrameworkDbContextTests
    {
        private string _connectionString;
        private Stopwatch _stopwatchtimer;

        [OneTimeSetUp]
        public void Setup()
        {
            _stopwatchtimer = new Stopwatch();
            _connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-9MCCCFM",
                InitialCatalog = "AdventureWorks2014",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }.ToString();

            _stopwatchtimer.Start();
            using (var ctx = new ThickDbContext(_connectionString))
            {
                InteractiveViews.SetViewCacheFactory(
                    ctx, new FileViewCacheFactory(@"c:\Users\User\Desktop\GitLab\POC.EF.Tests\viewCache.xml"));
            }
            _stopwatchtimer.Stop();
            Debug.WriteLine($"View chache generation: {_stopwatchtimer.ElapsedMilliseconds}");
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Get_InitThickDbContext_DurationTimes(int id)
        {
            _stopwatchtimer.Reset();
            _stopwatchtimer.Start();
            using (var ctx = new ThickDbContext(_connectionString))
            {   
                var data = ctx.Addresses.SingleOrDefault(adr => adr.AddressID == id);
            }

            _stopwatchtimer.Stop();
            Debug.WriteLine($"Id: {id} Duration: {_stopwatchtimer.ElapsedMilliseconds}");
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public void Get_FirstRequest_EstimatedTime(int id)
        {
            using (var dbContext = new AdventureWorksDbContext(_connectionString))
            {
                _stopwatchtimer.Start();

                var response1 = dbContext.Addresses.SingleOrDefault(adr => adr.AddressID == id);

                _stopwatchtimer.Stop();

                Debug.WriteLine($"param: {id}   Duration:{_stopwatchtimer.Elapsed.Milliseconds}");
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
