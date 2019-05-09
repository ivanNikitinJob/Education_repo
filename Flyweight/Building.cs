using System;

namespace Flyweight
{
    public class Building
    {
        public string Address { get; }
        public DateTime StartOfConstruction { get; }
        public BuildingPlan BuildingPlan { get; }

        public Building(string address, BuildingPlan plan)
        {
            Address = address;
            BuildingPlan = plan;
            StartOfConstruction = DateTime.UtcNow;
        }
    }
}
