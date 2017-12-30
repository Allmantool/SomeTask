using System;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Facade.Implementation
{
    public class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написание кода");
        }
        public void Save()
        {
            Console.WriteLine("Сохранение кода");
        }
    }
}
