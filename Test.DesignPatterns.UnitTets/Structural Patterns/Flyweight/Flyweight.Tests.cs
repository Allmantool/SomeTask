using NUnit.Framework;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Abstract;
using Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight.Implementation;

namespace Test.DesignPatterns.UnitTets.Structural_Patterns.Flyweight
{
    [TestFixture]
    public class Flyweight
    {
        [Test]
        public void Example()
        {
            double longitude = 37.61;
            double latitude = 55.74;

            var houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House panelHouse = houseFactory.GetHouse("Panel");
                panelHouse?.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                House brickHouse = houseFactory.GetHouse("Brick");
                brickHouse?.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }
        }
    }
}
