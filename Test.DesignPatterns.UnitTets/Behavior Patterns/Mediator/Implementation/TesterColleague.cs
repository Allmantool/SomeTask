using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Implementation
{
    public class TesterColleague : Colleague
    {
        public TesterColleague(TheMediator mediator)
            : base(mediator)
        { }
 
        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестеру: " + message);
        }
    }
}
