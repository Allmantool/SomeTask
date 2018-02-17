using Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy.Interfaces;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Strategy
{
    public class Car
    {
        protected int passengers; // кол-во пассажиров
        protected string model; // модель автомобиля
        public IMovable Movable { private get; set; }

        public Car(int num, string model, IMovable mov)
        {
            this.passengers = num;
            this.model = model;
            Movable = mov;
        }
        
        public void Move()
        {
            Movable.Move();
        }
    }
}
