using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Abstraction;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator
{
    [TestFixture()]
    public class Mediator
    {
        [Test]
        public void MainTest()
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("Есть заказ, надо сделать программу");
            programmer.Send("Программа готова, надо протестировать");
            tester.Send("Программа протестирована и готова к продаже");
        }
    }
}
