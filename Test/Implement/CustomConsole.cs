using System;
using Test.Abstract;
/// <summary>
/// Custom stupid console
/// </summary>
namespace Test.Implement {
    public class CustomConsole : IConsole {
        public string Title { get; private set; }
        private string tips = $"{Environment.NewLine}Tip: " +
                              $"1) list ( optional: path ( C:\\)) - it represents all files and folders in directory{Environment.NewLine}" +
                              $"2) search where *.exe (regular expression) - it represents all files appropriate to regular expression mask in current folder{Environment.NewLine}" +
                              $"3) searchall where *.exe (regular expression) - it represents all files appropriate to regular expression mask in current folder and subfolders (recursion){Environment.NewLine}" +
                              $"4) simplesearch where *.exe - (alternative variant of 'search'){Environment.NewLine}" +
                              $"5) simplesearch where *.exe - (alternative variant of 'searchall' with hierarchy represantation{Environment.NewLine}" +
                              $"6) up - moves up to one level in directory tree (return current location){Environment.NewLine}" +
                              $"7) count - returns all subfolders count";

        public CustomConsole(string title) {
            Console.Title = title;
            Console.WriteLine(@"Hello, please select your commad(s) :)" + tips);
        }

        public void PrintOutput(string stringStream) {
            Console.WriteLine(stringStream);
        }

        public string ReadInput() {
            return Console.ReadLine();
        }

        public bool IsExit() {
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }
    }
}