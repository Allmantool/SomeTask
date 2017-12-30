using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Facade.Implementation;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Facade
{
    [TestFixture]
    public class Facade
    {
        [Test]
        public void Implementation()
        {
            var textEditor = new TextEditor();
            var compiller = new Compiller();
            var clr = new CLR();

            var ide = new VisualStudioFacade(textEditor, compiller, clr);

            var programmer = new Programmer();
            programmer.CreateApplication(ide);
        }
    }
}
