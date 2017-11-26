using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XMLTest {
    [TestClass]
    public class Decorator {
        [TestMethod]
        public void Main() {
            Pizza pizza1 = new ItalianPizza();
            // Italian pizza with tomatos.
            pizza1 = new TomatoPizza(pizza1);

            Writer.Output(pizza1);

            Pizza pizza2 = new ItalianPizza();
            // Italian pizza with cheese.
            pizza2 = new CheesePiza(pizza2);

            Writer.Output(pizza2);

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            // Bulgerian Pizza with tomatos and cheese.
            pizza3 = new CheesePiza(pizza3);

            Writer.Output(pizza3);
        }
    }

    public static class Writer {
        public static void Output(Pizza p) {
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"Cost: {p.GetCost()}");
        }

    }

    public class BulgerianPizza : Pizza {
        public BulgerianPizza() : base("Bolgarian pizza") {
        }

        public override int GetCost() {
            return 8;
        }
    }

    public abstract class Pizza {
        public string Name { get; }
        public abstract int GetCost();

        protected Pizza(string n) {
            this.Name = n;
        }
    }

    public class ItalianPizza : Pizza {
        public ItalianPizza() : base("Italian pizza") { }

        public override int GetCost() {
            return 10;
        }
    }

    class TomatoPizza : PizzaDecorator {
        public TomatoPizza(Pizza p) : base(p.Name + ", with tomatos", p) {
        }

        public override int GetCost() {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePiza : PizzaDecorator {
        public CheesePiza(Pizza p) : base(p.Name + ", with cheese", p) {
        }

        public override int GetCost() {
            return pizza.GetCost() + 5;
        }
    }

    abstract class PizzaDecorator : Pizza {
        protected Pizza pizza;

        protected PizzaDecorator(string n, Pizza pizza) : base(n) {
            this.pizza = pizza;
        }
    }
}
