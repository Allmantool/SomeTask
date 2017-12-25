using Test.DesignPatterns.UnitTets.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion
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
