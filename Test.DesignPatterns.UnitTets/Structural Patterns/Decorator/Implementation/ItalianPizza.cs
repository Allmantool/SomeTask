using Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Implementation
{
    public class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
}
