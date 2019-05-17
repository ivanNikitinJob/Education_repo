using Flyweight.Entities;
using Flyweight.Interfaces;
using RandomNameGeneratorLibrary;
using System.Threading.Tasks;

namespace Flyweight.Builders
{
    public class SimpleBuilder : IBuilder
    {
        private Building _building;
        public async void BuildAsync(BuildingPlan selectPlan)
        {
            await Task.Run(() =>
            {
                var address = new PlaceNameGenerator().GenerateRandomPlaceName();
                _building = new Building(address, selectPlan);
            });
        }

        public Building GetBuilding()
        {
            return _building;
        }
    }
}
