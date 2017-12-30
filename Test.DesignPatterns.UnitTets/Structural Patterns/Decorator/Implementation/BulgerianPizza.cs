using Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Implementation
{
    public class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }
}
