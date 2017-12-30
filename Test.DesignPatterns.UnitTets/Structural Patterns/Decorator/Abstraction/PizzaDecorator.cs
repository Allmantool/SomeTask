namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction
{
    public abstract class PizzaDecorator : Pizza
    {
        protected readonly Pizza Pizza;

        protected PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.Pizza = pizza;
        }
    }
}
