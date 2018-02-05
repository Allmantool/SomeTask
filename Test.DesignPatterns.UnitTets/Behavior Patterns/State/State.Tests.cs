using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Behavior_Patterns.State.Implementation;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.State
{
    [TestFixture]
    public class StatePattern
    {
        [Test]
        public void Main()
        {
            // Open a new account

            Account account = new Account("Jim Johnson");

            // Apply financial transactions

            account.Deposit(500.0);
            account.Deposit(300.0);
            account.Deposit(550.0);
            account.PayInterest();
            account.Withdraw(2000.00);
            account.Withdraw(1100.00);
        }
    }
}
