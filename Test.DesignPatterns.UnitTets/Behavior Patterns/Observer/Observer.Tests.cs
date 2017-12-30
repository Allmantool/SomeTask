using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Observer
{
    [TestFixture]
    public class Observer
    {
        [Test]
        public void StockTest()
        {
            Stock stock = new Stock();
            Bank bank = new Bank("ЮнитБанк", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            // имитация торгов
            stock.Market();
        }
    }
}
