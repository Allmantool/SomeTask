using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Interfaces;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Implementation
{
    public class PetrolMove: IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }
}
