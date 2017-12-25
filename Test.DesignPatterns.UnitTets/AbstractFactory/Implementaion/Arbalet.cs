using System;

namespace Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion
{
    class Arbalet : UnitTets.AbstractFactory.Abstraction.Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
}
