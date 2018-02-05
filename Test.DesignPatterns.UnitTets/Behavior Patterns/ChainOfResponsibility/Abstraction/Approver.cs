using Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Abstraction
{
    public abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }
}
