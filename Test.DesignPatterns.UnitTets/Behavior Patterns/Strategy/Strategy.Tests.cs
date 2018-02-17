using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy
{
    public class Strategy
    {
        public void Main(string[] args)
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.ReadLine();
        }
    }
}