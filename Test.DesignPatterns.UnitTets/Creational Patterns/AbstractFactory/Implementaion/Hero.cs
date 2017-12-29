using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Implementaion
{
    public class Hero
    {
        private readonly Weapon _weapon;
        private readonly Movement _movement;
        public Hero(HeroFactory factory)
        {
            _weapon = factory.CreateWeapon();
            _movement = factory.CreateMovement();
        }
        public void Run()
        {
            _movement.Move();
        }
        public void Hit()
        {
            _weapon.Hit();
        }
    }
}
