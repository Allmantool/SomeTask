using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Abstraction;
using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Implementation
{
    public class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable _stock;
        public Broker(string name, IObservable obs)
        {
            Name = name;
            _stock = obs;
            _stock.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            Console.WriteLine(
                sInfo.USD > 30
                    ? "Брокер {0} продает доллары;  Курс доллара: {1}"
                    : "Брокер {0} покупает доллары;  Курс доллара: {1}", Name, sInfo.USD);
        }
        public void StopTrade()
        {
            _stock.RemoveObserver(this);
            _stock = null;
        }
    }
}
