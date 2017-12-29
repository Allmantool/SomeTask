using System;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Abstract;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Implementation
{
    class PanelHouse : House
    {
        public PanelHouse()
        {
            this.Stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен панельный дом из 16 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }
}
