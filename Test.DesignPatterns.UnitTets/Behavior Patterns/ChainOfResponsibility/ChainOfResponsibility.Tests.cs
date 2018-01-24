using System;
using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Abstraction;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.ChainOfResponsibility
{
    [TestFixture()]
    public class ChainOfResponsibility
    {
        [Test]
        public void MainTest()
        {
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            // Wait for user
            Console.ReadKey();
        }
    }
}