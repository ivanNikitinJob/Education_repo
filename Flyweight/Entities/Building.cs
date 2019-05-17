using Flyweight.Services;

namespace Flyweight.Entities
{
    public class Building
    {
        private BuildingService _buildingService;
        public string Address { get; }
        public int HumanCount { get; set; }
        public BuildingPlan BuildingPlan { get; }

        public Building(string address, BuildingPlan plan)
        {
            Address = address;
            BuildingPlan = plan;
            _buildingService = new BuildingService(this);
        }

        public int AddDwellers(int amount) => _buildingService.AddDwellers(amount);

        public int RemoveDwellers(int amount) => _buildingService.RemoveDwellers(amount);
    }
}
