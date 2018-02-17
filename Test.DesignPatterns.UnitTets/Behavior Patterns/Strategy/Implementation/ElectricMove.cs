using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Interfaces;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Implementation
{
    public class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
}
