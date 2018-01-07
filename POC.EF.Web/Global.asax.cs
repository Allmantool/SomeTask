using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using POC.EF.Web.DAL;

namespace POC.EF.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // We can pass as many connections string as we want. 
            // And then iterate throught them creating and caching dbcontext views.
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "DESKTOP-9MCCCFM",
                InitialCatalog = "AdventureWorks2014",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            }.ToString();

            // Warming up.
            Start(() =>
            {
                using (var dbContext = new AdventureWorksContext(connectionString))
                {
                    dbContext.Configuration.AutoDetectChangesEnabled = false;
                    dbContext.Configuration.LazyLoadingEnabled = false;
                    dbContext.Configuration.ProxyCreationEnabled = false;

                    var response1 = dbContext.Addresses.Count();
                }
            });
        }

        private void Start(Action a)
        {
            a.BeginInvoke(null, null);
        }
    }
}
