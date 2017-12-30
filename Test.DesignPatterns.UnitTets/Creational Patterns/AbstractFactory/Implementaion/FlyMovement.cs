using System;
using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Implementaion
{
    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
}
