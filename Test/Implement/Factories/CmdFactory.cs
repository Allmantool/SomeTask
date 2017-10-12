using System;
using Test.Abstract;
using Test.Implement.Commands;

namespace Test.Implement {
    public class CmdFactory : ICreator {
        private ICmd cmd;
        public DirectorySpider Spider { get; private set; }

        public CmdFactory(DirectorySpider spider) {
            Spider = spider;
        }

        public ICmd Build(string[] args) {
            switch (args[0]) {
                //up
                case "up":
                cmd = new UpCmd(Spider.Up());
                break;
                //list (optional:) path
                case @"list":
                Spider.CnageLocation(args.Length > 1 ? args[1] : Spider.CurrLocation.FullName);
                cmd = new SearchCmd(Spider.CurrLocation.FullName);
                break;
                // seach where *.exe* 
                case @"search":
                cmd = new SearchCmd(Spider.CurrLocation.FullName, args.Length > 1 ? args[2] : "*", isSearchMode: true);
                break;
                // seachall where *.exe* 
                case @"searchall":
                cmd = new SearchCmd(Spider.CurrLocation.FullName, args.Length > 1 ? args[2] : "*", true, true);
                break;
                // count
                case @"count":
                cmd = new CountSubFoldersCmd(Spider.CurrLocation.FullName);
                break;
                // simplesearch where *.exe
                case @"simplesearch":
                cmd = new SimpleCmd(args[2], location: Spider.CurrLocation.FullName);
                break;
                // simplesearchall where *.exe
                case @"simplesearchall":
                cmd = new SimpleCmd(args[2], true, Spider.CurrLocation.FullName);
                break;
                default:
                throw new Exception(message:"Wrong command for factory!");
            }

            return cmd;
        }
    }
}
