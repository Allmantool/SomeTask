using System.IO;
using System.Linq;
using Test.Abstract;

namespace Test.Implement.Commands {
    public class CountSubFoldersCmd : ICmd {
        public string Location { get; private set; }

        public CountSubFoldersCmd(string location) {
            Location = location;
        }

        public string Run() {
            var count = new DirectoryInfo(Location).GetDirectories("*", SearchOption.AllDirectories).Count();

            return $"Total count of root forlders and subfolders: {count}";
        }
    }
}