namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Abstraction
{
    public abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(int condition);
    }
}
