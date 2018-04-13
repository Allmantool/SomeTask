using System;
using System.Threading.Tasks;

namespace TPL.Tests.Helpers
{
    public class TestHarness
    {
        public static void TestAsyncBehaviour(Func<Task> test)
        {
            new DedicatedThreadSynchronisationContext().Send(state =>
            {
                test().Wait();
            }, null);
        }
    }
}