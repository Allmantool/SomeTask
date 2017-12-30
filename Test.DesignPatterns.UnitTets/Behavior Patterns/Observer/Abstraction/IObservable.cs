using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Abstraction
{
    public interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }
}
