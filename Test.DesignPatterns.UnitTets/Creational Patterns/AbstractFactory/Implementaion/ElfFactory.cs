using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Implementaion
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
