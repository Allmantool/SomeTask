using Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Implementation
{
    public class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return Pizza.GetCost() + 3;
        }
    }
}
