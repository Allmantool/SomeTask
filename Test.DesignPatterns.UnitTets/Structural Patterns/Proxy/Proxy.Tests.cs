using System;
using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Proxy.Implementation;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Proxy
{
    [TestFixture]
    public class Proxy
    {
        [Test]
        public void ProxyTest()
        {
            // Create math proxy

            MathProxy proxy = new MathProxy();

            // Do the math

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));

            // Wait for user

            Console.ReadKey();
        }
    }
}
