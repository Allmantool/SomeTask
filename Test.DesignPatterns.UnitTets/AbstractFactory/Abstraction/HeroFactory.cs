namespace Test.DesignPatterns.UnitTets.AbstractFactory.Abstraction
{
    public abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
}
