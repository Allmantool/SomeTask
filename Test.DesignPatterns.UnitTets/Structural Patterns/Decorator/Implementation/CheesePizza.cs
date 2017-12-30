using Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Implementation
{
    public class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return Pizza.GetCost() + 5;
        }
    }
}
