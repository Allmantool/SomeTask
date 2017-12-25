using FluentAssertions;
using NUnit.Framework;
using Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion;

namespace Test.DesignPatterns.UnitTets.AbstractFactory
{
    [TestFixture]
    public class AbstractFactory
    {
        [Test]
        public void Creation_IsNotNull_NewInstance()
        {
            Hero elf = new Hero(new ElfFactory());

            elf.Hit();
            elf.Run();

            elf.Should().NotBeNull();
        }
    }
}
