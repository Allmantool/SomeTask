namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction
{
    public abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
}
