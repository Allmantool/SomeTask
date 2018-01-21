namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.Mediator.Abstraction
{
    public abstract class Colleague
    {
        protected TheMediator mediator;

        public Colleague(TheMediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }
        public abstract void Notify(string message);
    }
}
