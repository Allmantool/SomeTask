using System;

namespace Test.DesignPatterns.UnitTets.Behavior_Patterns.State.Implementation
{
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class Account
    {
        private Abstraction.State _state;
        private string _owner;

        // Constructor
        public Account(string owner)
        {
            // New accounts are 'Silver' by default
            this._owner = owner;
            this._state = new SilverState(0.0, this);
        }

        // Properties

        public double Balance
        {
            get { return _state.Balance; }
        }

        public Abstraction.State State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}",
                this.State.GetType().Name);
            Console.WriteLine("");
        }

        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
                this.State.GetType().Name);
        }

        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
                this.State.GetType().Name);
        }
    }
}