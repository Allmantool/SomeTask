using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Implementation
{
    public class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(TheMediator mediator)
            : base(mediator)
        { }
 
        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }
}
