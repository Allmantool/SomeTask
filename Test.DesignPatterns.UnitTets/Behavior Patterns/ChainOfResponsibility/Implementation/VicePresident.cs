using System;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Abstraction;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Implementation
{
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
}
