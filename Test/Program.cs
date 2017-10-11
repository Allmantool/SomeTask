using Test.Implement;

namespace Test {
    public class Program {
        /// <summary>
        /// Console app.
        /// Write me back once you are ready or anything needs to be clarified.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            var butcher = new StringButcher(new CustomConsole("Serious task"), new DirectorySpider());

            //get command and proccesing them
            butcher.ChopCommands();
        }
    }
}