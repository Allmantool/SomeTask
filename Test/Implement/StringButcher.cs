using System;
using Test.Abstract;

namespace Test.Implement {
    /// <summary>
    /// Class that has responsobility work with input commands (parse and choose right continues strategy)
    /// // давай туда впилим стратегии и комманды.
    /// что бы консоль была тупая - 
    /// 1)умеет считать строку и вернуть
    /// 2)и умеет принять строку и вывести
    /// 3)а работа по распаршиванию строки была вынесена отдельно
    /// 4)что бы там какую-нить фабрику заюзать - которая тебе будет конструировать эту команду, и твой спайдер например её будет исполнять
    /// </summary>
    public class StringButcher {
        public IConsole BcConsole { get; private set; }
        public DirectorySpider Spider { get; private set; }
        private ICmd cmd;
        private ICreator creator;

        public StringButcher(IConsole cons, DirectorySpider spider) {
            BcConsole = cons;
            Spider = spider;
            creator = new CmdFactory(spider);
        }

        public void ChopCommands() {
            do {
                var splitCmd = BcConsole.ReadInput().ToLower().Split(null);

                //escape with 'exit' programe'
                if (splitCmd[0] == "exit") break;
                try {
                    cmd = creator.Build(splitCmd);
                } catch (Exception ex) {
                    BcConsole.PrintOutput($"" +
                        $"Wroing API for insisted commands!{Environment.NewLine}" +
                        $"1)list  (optional:) path{Environment.NewLine}" +
                        $"2)seach where *.exe*{Environment.NewLine}" +
                        $"3)seachall where *.exe*{Environment.NewLine}" +
                        $"4)simplelist{Environment.NewLine}" +
                        $"5)simplesearch where *.exe{Environment.NewLine}" +
                        $"6)simplesearchall where *.exe{Environment.NewLine}" +
                        $"Please, don't be upset and try again!{Environment.NewLine}" +
                        $"System exception: {ex.Message}{Environment.NewLine}"
                    );
                }
                //send command to spider
                Spider.Commands.Push(cmd);
                // print result
                BcConsole.PrintOutput(Spider.ExucCmd() + $"{Environment.NewLine}");

            } while (BcConsole.IsExit());
        }
    }
}