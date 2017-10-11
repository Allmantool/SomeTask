using System.IO;
using Test.Abstract;

namespace Test.Implement.Commands {
    public class UpCmd : ICmd {
        public string Location { get; private set; }

        public UpCmd(string location) {
            Location = location;
        }

        public string Run() {
            return new DirectoryInfo(Location).Parent.FullName;
        }
    }
}
