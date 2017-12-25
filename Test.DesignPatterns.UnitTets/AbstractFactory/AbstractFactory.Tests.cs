using Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion;

namespace Test.DesignPatterns.UnitTets.AbstractFactory
{
    public class AbstractFactory
    {
        Hero elf = new Hero(new ElfFactory());
        //elf.Hit();
        //elf.Run();
 
        Hero voin = new Hero(new VoinFactory());
        //voin.Hit();
        //voin.Run();

        
        
    }
}
