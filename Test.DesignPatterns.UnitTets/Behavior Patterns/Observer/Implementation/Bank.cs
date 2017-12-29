using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Abstraction;
using Test.DesignPatterns.UnitTets.Creational_Patterns.AbstractFactory.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Implementation
{
    public class Bank: IObserver
    {
        private string Name { get; set; }
        private readonly IObservable _stock;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            _stock = obs;
            _stock.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            Console.WriteLine(
                sInfo.Euro > 40 ? "Банк {0} продает евро;  Курс евро: {1}" : "Банк {0} покупает евро;  Курс евро: {1}",
                this.Name, sInfo.Euro);
        }
    }
}
