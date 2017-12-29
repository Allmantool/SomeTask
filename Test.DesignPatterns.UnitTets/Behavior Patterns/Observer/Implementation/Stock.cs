using System;
using System.Collections.Generic;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Abstraction;
using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Implementation
{
    public class Stock : IObservable
    {
        private readonly StockInfo _sInfo; // информация о торгах

        private readonly List<IObserver> _observers;

        public Stock()
        {
            _observers = new List<IObserver>();
            _sInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(_sInfo);
            }
        }

        public void Market()
        {
            var rnd = new Random();
            _sInfo.USD = rnd.Next(20, 40);
            _sInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }
}
