namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Abstraction
{
    public abstract class TheMediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }
}
