using Flyweight.Entities;

namespace Flyweight.Services
{
    public class BuildingService
    {
        private Building _building;

        public BuildingService(Building building)
        {
            _building = building;
        }
        public int AddDwellers(int amount)
        {
            var emptySlots = _building.BuildingPlan.HumanCapacity - _building.HumanCount;
            if (emptySlots < 1)
            {
                return 0;
            }

            if (emptySlots > amount)
            {
                _building.HumanCount += amount;
                return amount;
            }

            _building.HumanCount += emptySlots;
            return emptySlots;
        }

        public int RemoveDwellers(int amount)
        {
            if (amount <= _building.HumanCount)
            {
                _building.HumanCount -= amount;
                return amount;
            }

            _building.HumanCount = 0;
            return _building.HumanCount;
        }
    }
}
