using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using static System.Console;

namespace Pluralsight.Dynamic.Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RunStrBuilder()
        {
            var sb = new StringBuilder();

            ((dynamic)sb).AppendLine("Hello dynamic");

            sb.GetType().InvokeMember("AppendLine",
                BindingFlags.InvokeMethod,
                null,
                sb,
                new object[] { "Hello" });

            WriteLine(sb);
        }

        public void ParseJsonDynamic()
        {
            //dynamic jsonData = JsonConverter.DeserializeObject(File.ReadAllText("peoples.json"));

            //foreach (dynamic people in jsonData.peoples)
            //{
            //    var name = people.firstName;
            //}
        }

        [TestMethod]
        public void SQLDynamic()
        {
            const string connectionString = @"data Source=.;initial catalog=IPManagerDev;integrated security=True;Trusted_Connection=Yes";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Open();

                // Get dynamic instances.
                IEnumerable<dynamic> currences = cn.Query("SELECT * FROM CURRENCIES");


                var count = currences.Count();
                // Apply Linq filter.
                var result = currences.Where(x => x.CURRENCYID == 2);

                foreach (var cust in result)
                {
                    WriteLine($"{cust.CURRENCYCODE}");
                }
            }

            WriteLine("\n\nPress enter to exit...");
            ReadLine();
        }
    }
}
