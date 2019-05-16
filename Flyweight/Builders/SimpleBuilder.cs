using Flyweight.Entities;
using Flyweight.Interfaces;
using RandomNameGeneratorLibrary;

namespace Flyweight.Builders
{
    public class SimpleBuilder : IBuilder
    {
        private Building _building;
        public void Build(BuildingPlan selectPlan)
        {
            var address = new PlaceNameGenerator().GenerateRandomPlaceName();
            _building = new Building(address, selectPlan);
        }

        public Building GetBuilding()
        {
            return _building;
        }
    }
}
