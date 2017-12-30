using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Implementaion
{
    public class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
}
