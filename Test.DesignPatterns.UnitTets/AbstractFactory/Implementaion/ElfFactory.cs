using Test.DesignPatterns.UnitTets.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.AbstractFactory.Implementaion
{
    public class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
}
