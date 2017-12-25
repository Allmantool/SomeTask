using System;
using Test.DesignPatterns.UnitTets.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion
{
    public class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
}
