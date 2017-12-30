using System;
using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Implementaion
{
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
}
