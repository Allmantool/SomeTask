using System;
using System.Collections.Generic;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Composite.Abstraction;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Composite.Implementation
{
    public class Directory : Component
    {
        private readonly IList<Component> _components = new List<Component>();

        public Directory(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Узел " + Name);
            Console.WriteLine("Подузлы:");
            foreach (var t in _components)
            {
                t.Print();
            }
        }
    }
}
