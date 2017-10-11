using System;
using Test.Abstract;
/// <summary>
/// Custom stupid console
/// </summary>
namespace Test.Implement {
    public class CustomConsole : IConsole {
        public string Title { get; private set; }

        public CustomConsole(string title) {
            Console.WriteLine(@"Hello, please select your commad(s) :)");
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