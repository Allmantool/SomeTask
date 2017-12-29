using System.Collections.Generic;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Abstract;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Implementation
{
    public class HouseFactory
    {
        private readonly Dictionary<string, House> _houses = new Dictionary<string, House>();
        public HouseFactory()
        {
            _houses.Add("Panel", new PanelHouse());
            _houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (_houses.ContainsKey(key))
                return _houses[key];
            else
                return null;
        }
    }
}
