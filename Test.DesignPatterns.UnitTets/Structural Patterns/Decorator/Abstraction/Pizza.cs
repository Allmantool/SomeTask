namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Decorator.Abstraction
{
    public abstract class Pizza
    {
        protected Pizza(string n)
        {
            Name = n;
        }
        public string Name { get; private set; }
        public abstract int GetCost();
    }
}
